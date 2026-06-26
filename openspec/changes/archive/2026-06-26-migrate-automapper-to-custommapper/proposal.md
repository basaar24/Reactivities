## Why

AutoMapper is a third-party NuGet dependency used exclusively for two trivial convention-based mappings between same-named properties. Replacing it with a hand-written mapper eliminates the external dependency, removes profile scanning and DI registration overhead, and makes mapping logic explicit and immediately readable without indirection.

## Agent Role

**backend-developer** — this change is entirely within the C# backend (Application and API projects). No frontend changes.

## What Changes

- **Add** `IActivityMapper` interface (`Application/Core/`) defining two mapping methods.
- **Add** `ActivityMapper` implementation (`Application/Core/`) with explicit property assignments.
- **Replace** `AddAutoMapper(...)` in `API/Program.cs` with `AddScoped<IActivityMapper, ActivityMapper>()`.
- **Update** `CreateActivity.Handler` — replace `IMapper` injection with `IActivityMapper`; replace `mapper.Map<Activity>()` call with `IActivityMapper.ToActivity()`.
- **Update** `UpdateActivity.Handler` — replace `IMapper` injection with `IActivityMapper`; replace `mapper.Map(source, destination)` call with `IActivityMapper.UpdateActivity()`.
- **Delete** `Application/Core/Mappings/MappingProfiles.cs` and the `Mappings/` directory.
- **Remove** `AutoMapper` NuGet package from `Application/Application.csproj`.

## Capabilities

### New Capabilities

- `activity-mapping`: A custom, hand-written mapper that converts `CreateActivityRequest → Activity` and copies properties between two `Activity` instances for update operations. No reflection, no third-party library, no profile registration.

### Modified Capabilities

_(None — no spec-level API or domain behavior changes. The mapping contract is identical; only the implementation mechanism changes.)_

## Non-goals

- No changes to the `Activity` domain entity or `CreateActivityRequest` DTO.
- No changes to the API contract (`/api/activities` endpoints remain identical).
- No changes to response shapes or frontend code.
- No introduction of a general-purpose mapping framework or generic mapper abstraction.

## Impact

- **Removed dependency**: `AutoMapper` NuGet package from `Application/Application.csproj`.
- **Affected files**: `Program.cs`, `CreateActivity.cs`, `UpdateActivity.cs`, `MappingProfiles.cs` (deleted).
- **New files**: `Application/Core/IActivityMapper.cs`, `Application/Core/ActivityMapper.cs`.
- **No API contract changes** — `docs/api-spec.yml` unchanged.
- **No data model changes** — `docs/data-model.md` unchanged.
- **Backend standards reference**: `docs/backend-standards.md` mentions AutoMapper; it should be updated to reflect the custom mapper pattern after implementation.
