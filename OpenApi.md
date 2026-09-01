# Manual setup — OpenAPI doc generation + typed client for the Reactivities API

This is the full procedure for standing up OpenAPI support for the Reactivities
backend: a standalone doc-generation host (`API.OpenApi`), an NSwag codegen
config (`nswag/`), and the generated OpenAPI document (`openapi/`).

It is a two-part process: **(1) scaffold the pieces by hand**, then **(2) run the
generation pipeline** to populate the generated content.

All paths below are relative to `backend/` (the folder containing
`Reactivities.slnx`).

Repo layout produced by this procedure:

| Path                                                               | Purpose                                             |
| ------------------------------------------------------------------ | --------------------------------------------------- |
| `backend/API.OpenApi/`                                             | Standalone host that serves the live Swagger doc/UI |
| `backend/nswag/API.nswag`                                          | Checked-in NSwag codegen config                     |
| `backend/openapi/Reactivities.v1.json`                             | Generated OpenAPI document (never hand-edited)      |
| `backend/API.OpenApi/Generated/ReactivitiesRpcClient.generated.cs` | Generated C# client (never hand-edited)             |

---

## Part 1 — Manually scaffold the pieces

### Step 1: Create `API.OpenApi/` (the standalone doc-generation host)

Run from `backend/`:

```powershell
dotnet new web -n API.OpenApi -o API.OpenApi
dotnet sln Reactivities.slnx add API.OpenApi/API.OpenApi.csproj
```

> Note: `Reactivities.slnx` currently lists only `API`, `Application`, `Domain`,
> and `Persistence`. Adding `API.OpenApi` to the solution is optional — the
> pipeline in Part 2 targets the `.csproj` directly — but keeping it in the
> solution makes it build with `dotnet build Reactivities.slnx`.

Then edit `API.OpenApi/API.OpenApi.csproj` to match this shape:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Moq" Version="4.20.72" />
    <PackageReference Include="NSwag.AspNetCore" Version="14.7.1" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\API\API.csproj" />
  </ItemGroup>

</Project>
```

- `ProjectReference` to `API` is what lets this host discover the real
  controllers (`ActivitiesController`, `BuggyController`) via an MVC application
  part.
- `NSwag.AspNetCore` serves the live Swagger doc/UI.
- `Moq` is only needed if a controller gains constructor dependencies that must
  be registered for the host to start (see Step 2). The current controllers
  don't have any, so `Moq` is effectively unused today — keep it for forward
  compatibility or drop it.

Then replace `Program.cs` with a minimal host that:

1. Registers `AddOpenApiDocument(...)` with a fixed `DocumentName` / `Title` /
   `Version`.
2. Loads the `API` assembly via `Assembly.GetAssembly(typeof(API.Program))` and
   adds it as an MVC application part with `AddControllersAsServices()`.
3. Registers any controller-constructor dependencies. The Reactivities
   controllers resolve `IMediator` lazily from `HttpContext.RequestServices`
   (see `API/Controllers/BaseApiController.cs`), so **no mocks are required
   today**. Only add `services.AddSingleton(new Mock<INewService>().Object);`
   lines if a future controller takes real constructor parameters.
4. Calls `app.UseOpenApi()` / `app.UseSwaggerUi()` / `app.MapControllers()`.

A working `Program.cs` already exists at `backend/API.OpenApi/Program.cs`. It
sets Newtonsoft camelCase contract resolution to match the API's serialization,
then:

```csharp
services
    .AddOpenApiDocument(document =>
    {
        document.DocumentName = "Reactivities";
        document.Title = "ReactivitiesV1"; // Official interface name. No spaces. PascalCase.
        document.Version = "1.0.0";
        document.DefaultResponseReferenceTypeNullHandling =
            NJsonSchema.Generation.ReferenceTypeNullHandling.NotNull;
    });

var pluginAssembly = Assembly.GetAssembly(typeof(API.Program));
services.AddMvc()
    .AddApplicationPart(pluginAssembly!)
    .AddControllersAsServices()
    .AddNewtonsoftJson(/* camelCase resolver */);
```

> The `DocumentName` ("Reactivities") is what forms the Swagger JSON URL in
> Part 2: `/swagger/Reactivities/swagger.json`.

Finally, set `API.OpenApi/properties/launchSettings.json` to this project's
name and a free port pair (the main API uses 5000/5001):

```json
{
  "profiles": {
    "API.OpenApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "applicationUrl": "https://localhost:5011;http://localhost:5010"
    }
  }
}
```

### Step 2: Create `openapi/` (generated output folder)

```powershell
mkdir openapi
```

Leave it empty — `Reactivities.v1.json` is pure generated output (Part 2) and
must never be hand-authored.

### Step 3: Create `nswag/API.nswag` (checked-in codegen config)

```powershell
mkdir nswag
```

This file **is** hand-authored / checked in (unlike the JSON doc or the
generated `.cs`). Create `nswag/API.nswag` pointing at the not-yet-existing
OpenAPI doc as input and the `API.OpenApi/Generated/` folder as output:

```json
{
  "runtime": "Net100",
  "documentGenerator": {
    "fromDocument": {
      "url": "../openapi/Reactivities.v1.json"
    }
  },
  "codeGenerators": {
    "openApiToCSharpClient": {
      "generateClientClasses": true,
      "generateClientInterfaces": true,
      "generateExceptionClasses": true,
      "exceptionClass": "ApiException",
      "className": "{controller}RpcClient",
      "operationGenerationMode": "MultipleClientsFromOperationId",
      "namespace": "API.OpenApi.Client",
      "jsonLibrary": "NewtonsoftJson",
      "output": "../API.OpenApi/Generated/ReactivitiesRpcClient.generated.cs"
    }
  }
}
```

Two gotchas:

- `"runtime"` must match the SDK you actually run NSwag with — `"Net100"` for
  `net10.0`. NSwag throws `InvalidOperationException` if it doesn't match the
  running process.
- `generateExceptionClasses` must be `true`. Leaving it `false` compiles fine
  against an empty controller surface but breaks once real operations exist and
  the generated client references an `ApiException` type that was never emitted.

### Step 4: Register the NSwag CLI as a local tool

Run from `backend/` (there is no `.config/dotnet-tools.json` in this repo yet):

```powershell
dotnet new tool-manifest
dotnet tool install nswag.consolecore --version 14.7.1
dotnet tool restore
```

This produces `backend/.config/dotnet-tools.json` with an `nswag` command — a
local (not global) tool, so the pipeline is reproducible per-machine / CI
without mutating global state.

---

## Part 2 — Populate the generated content

Run from `backend/`.

1. **Start the host** (separate terminal, or background it):

```powershell
dotnet run --project API.OpenApi/API.OpenApi.csproj --no-launch-profile --urls http://127.0.0.1:5011
```

Wait for `Now listening on: http://127.0.0.1:5011`.

2. **Fetch the document into the `openapi/` folder:**

```powershell
Invoke-WebRequest -Uri http://127.0.0.1:5011/swagger/Reactivities/swagger.json -OutFile openapi/Reactivities.v1.json
```

3. **Stop the host** (so it doesn't lock its own `.exe` during the rebuild):

```powershell
Get-Process -Name "API.OpenApi" | Stop-Process -Force
```

4. **Generate the C# client** from that JSON, using `nswag/API.nswag`:

```powershell
dotnet tool run nswag run nswag/API.nswag
```

If `dotnet tool run nswag` reports the tool isn't available even after `dotnet tool restore`, invoke the NSwag console DLL directly instead:

```powershell
dotnet "$env:NUGET_PACKAGES\nswag.consolecore\14.7.1\tools\net10.0\any\dotnet-nswag.dll" run src\nswag\API.nswag
```

This writes `API.OpenApi/Generated/ReactivitiesRpcClient.generated.cs`.

5. **Rebuild the solution to confirm everything compiles:**

```powershell
dotnet build Reactivities.slnx
```

---

## Summary of what gets created vs. hand-maintained

| Path                                                        | Origin                     | Maintenance                                                   |
| ----------------------------------------------------------- | -------------------------- | ------------------------------------------------------------- |
| `API.OpenApi/*.csproj`, `Program.cs`, `launchSettings.json` | Manual (Part 1)            | Hand-edit when adding new controller dependencies to register |
| `nswag/API.nswag`                                           | Manual (Part 1)            | Hand-edit only for codegen config changes (e.g. runtime bump) |
| `openapi/Reactivities.v1.json`                              | Generated (Part 2, step 2) | **Never hand-edit** — overwritten by the pipeline             |
| `API.OpenApi/Generated/*.generated.cs`                      | Generated (Part 2, step 4) | **Never hand-edit** — overwritten by the pipeline             |

---

## Validation notes — discrepancies in the current checked-in files

The three pieces already exist on this branch but still carry names from the
project they were copied from. Fix these before running Part 2:

| File                                                       | Current value                                                          | Should be                                                                                                        |
| ---------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| `nswag/API.nswag` → `runtime`                              | `"Net80"`                                                              | `"Net100"` (target is `net10.0` — NSwag will throw otherwise)                                                    |
| `nswag/API.nswag` → `fromDocument.url`                     | `"../openapi/SettingsHub.v1.json"`                                     | `"../openapi/Reactivities.v1.json"`                                                                              |
| `nswag/API.nswag` → `generateExceptionClasses`             | `false`                                                                | `true` (client references `ApiException`)                                                                        |
| `nswag/API.nswag` → `namespace`                            | `"Slb.Planck.SettingsHub.OpenApi.Client"`                              | `"API.OpenApi.Client"`                                                                                           |
| `nswag/API.nswag` → `output`                               | `"../SettingsHub.OpenApi/Generated/SettingsHubRpcClient.generated.cs"` | `"../API.OpenApi/Generated/ReactivitiesRpcClient.generated.cs"`                                                  |
| `API.OpenApi/Program.cs` → `document.DocumentName`         | `"SettingsHub"`                                                        | `"Reactivities"` (drives the `/swagger/{name}/swagger.json` URL)                                                 |
| `API.OpenApi/properties/launchSettings.json` → profile key | `"ConfigurationHub.OpenApi"`                                           | `"API.OpenApi"`                                                                                                  |
| `openapi/API.v1.json`                                      | filename                                                               | rename to `openapi/Reactivities.v1.json` (or keep `API.v1.json` and use that name consistently everywhere above) |
| `backend/.config/dotnet-tools.json`                        | missing                                                                | run Step 4 to create it                                                                                          |

`Program.cs` is otherwise correct for this repo: it references
`typeof(API.Program)`, references `..\API\API.csproj`, and needs no dependency
mocks because `BaseApiController` resolves `IMediator` from
`HttpContext.RequestServices` rather than the constructor.
