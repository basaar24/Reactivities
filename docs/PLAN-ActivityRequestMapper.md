# Plan: ActivityRequestMapper

## Context

`ActivityRequest` is a purpose-built DTO that omits `Id` and `IsCancelled` — the two fields that should never come from a client on create. Currently `CreateActivity.Command` accepts a raw `Activity` domain entity, meaning the controller binds directly from the JSON body into a domain object. The goal is to wire `ActivityRequest` through a dedicated mapper so the create flow matches the update flow pattern (request DTO → mapper → domain entity).

## Changes

### 1. New file — `Application/Common/Mappings/ActivityRequestMapper.cs`

- Implements `IMapper<ActivityRequest, Activity>` (same interface as `ActivityMapper`)
- No `namespace` declaration (matches `ActivityMapper.cs` and `IMapper.cs` which are in the global namespace)
- `using Domain;` and `using Application.Activities.Requests;` at the top
- `void Map(source, destination)` — copies the 8 writable fields; deliberately skips `Id` and `IsCancelled`
- `Activity Map(source)` — constructs `Activity` with the `required` properties, delegates to the two-arg overload, returns result
- No ignored-properties mechanic needed (unlike `ActivityMapper`) — the DTO already constrains what's allowed

```csharp
using Domain;
using Application.Activities.Requests;

public sealed class ActivityRequestMapper : IMapper<ActivityRequest, Activity>
{
    public void Map(ActivityRequest source, Activity destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);

        destination.Title       = source.Title;
        destination.Date        = source.Date;
        destination.Description = source.Description;
        destination.Category    = source.Category;
        destination.City        = source.City;
        destination.Venue       = source.Venue;
        destination.Latitude    = source.Latitude;
        destination.Longitude   = source.Longitude;
    }

    public Activity Map(ActivityRequest source)
    {
        var destination = new Activity
        {
            Title       = source.Title,
            Description = source.Description,
            Category    = source.Category,
            City        = source.City,
            Venue       = source.Venue,
        };

        Map(source, destination);
        return destination;
    }
}
```

### 2. Update `Application/Activities/Commands/CreateActivity.cs`

- Add `using Application.Activities.Requests;`
- `Command`: change property from `required Activity Activity` → `required ActivityRequest ActivityRequest`
- `Handler`: add `IMapper<ActivityRequest, Activity> mapper` to the primary constructor (same pattern as `UpdateActivity.Handler`)
- `Handle`: call `mapper.Map(request.ActivityRequest)` to produce the `Activity`, then add and save it

### 3. Update `API/Controllers/ActivitiesController.cs`

- Add `using Application.Activities.Requests;`
- `CreateActivity` action: parameter changes from `Activity activity` → `ActivityRequest activityRequest`
- Mediator send: `new CreateActivity.Command { ActivityRequest = activityRequest }`

### 4. Update `API/Program.cs`

- Add `using Application.Activities.Requests;` (needed for `ActivityRequest` type in the registration)
- Add one line after the existing mapper registration:
  ```csharp
  builder.Services.AddScoped<IMapper<ActivityRequest, Activity>, ActivityRequestMapper>();
  ```

## Execution Order

1. `ActivityRequestMapper.cs` (new — no upstream dependencies)
2. `CreateActivity.cs` (depends on mapper type)
3. `ActivitiesController.cs` (depends on Command shape)
4. `Program.cs` (depends on mapper class existing)

## Verification

```
dotnet build
```

Zero errors expected. Then POST to `/api/activities` with a body that has no `id` or `isCancelled` — should return a GUID. GET that GUID back to confirm `isCancelled: false` and a generated `id`.
