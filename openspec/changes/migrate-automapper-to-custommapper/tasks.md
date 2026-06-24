## 1. Add Custom Mapper Interface and Implementation

- [ ] 1.1 Create `backend/Application/Core/IActivityMapper.cs` with method signatures `Activity ToActivity(CreateActivityRequest request)` and `void UpdateActivity(Activity source, Activity destination)`
- [ ] 1.2 Create `backend/Application/Core/ActivityMapper.cs` implementing `IActivityMapper` — `ToActivity` copies `Title`, `Date`, `Description`, `Category`, `City`, `Venue`, `Latitude`, `Longitude` from the request to a new `Activity`; `UpdateActivity` copies the same fields plus `IsCancelled` from source to destination, leaving `destination.Id` unchanged

## 2. Update DI Registration

- [ ] 2.1 In `backend/API/Program.cs`, remove the `builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly)` call
- [ ] 2.2 In `backend/API/Program.cs`, add `builder.Services.AddScoped<IActivityMapper, ActivityMapper>()` with the appropriate `using` directives

## 3. Update MediatR Handlers

- [ ] 3.1 In `backend/Application/Activities/Commands/CreateActivity.cs`, replace the `IMapper mapper` constructor parameter with `IActivityMapper mapper`; replace `mapper.Map<Activity>(request.ActivityRequest)` with `mapper.ToActivity(request.ActivityRequest)`
- [ ] 3.2 In `backend/Application/Activities/Commands/UpdateActivity.cs`, replace the `IMapper mapper` constructor parameter with `IActivityMapper mapper`; replace `mapper.Map(request.Activity, activity)` with `mapper.UpdateActivity(request.Activity, activity)`

## 4. Remove AutoMapper

- [ ] 4.1 Delete `backend/Application/Core/Mappings/MappingProfiles.cs`
- [ ] 4.2 Remove the `<PackageReference Include="AutoMapper" ... />` entry from `backend/Application/Application.csproj`

## 5. Verify

- [ ] 5.1 Run `dotnet build` from the `backend/` directory and confirm **Build succeeded. 0 Error(s). 0 Warning(s).**
- [ ] 5.2 Run the API (`dotnet run --project API`) and confirm POST `/api/activities` creates an activity correctly and PUT `/api/activities` updates one correctly
- [ ] 5.3 Update `docs/backend-standards.md` to replace references to AutoMapper with the custom `IActivityMapper` pattern
