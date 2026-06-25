# Backend — Core

## Project Structure

```
backend/
├── API/                         # ASP.NET Core; thin controllers + Program.cs
│   └── Controllers/             # ActivitiesController
├── Application/
│   ├── Activities/
│   │   ├── Commands/            # CreateActivity, UpdateActivity, DeleteActivity
│   │   ├── Queries/             # GetActivityList, GetActivityDetails
│   │   └── Requests/            # DTOs: CreateActivityRequest (etc.)
│   └── Core/
│       ├── IActivityMapper.cs   # Mapping interface
│       └── ActivityMapper.cs    # Concrete implementation
├── Domain/
│   └── Activity.cs              # Sole domain entity
└── Persistence/
    ├── AppDbContext.cs           # EF Core DbContext; DbSet<Activity>
    ├── DbInitializer.cs          # Seeds 9 activities on startup if DB empty
    └── Migrations/
```

## Key registrations (Program.cs)

- `AddDbContext<AppDbContext>` — SQLite via connection string `DefaultConnection`
- `AddMediatR` — scanned from `Application` assembly
- `AddScoped<IActivityMapper, ActivityMapper>` — custom mapper (not AutoMapper)
- CORS: allows `http://localhost:3000` and `https://localhost:3000`
- On startup: `MigrateAsync()` + `DbInitializer.SeedData()`

## API Routes (`/api/activities`)

| Method | Path | Handler |
|---|---|---|
| GET | `/` | `GetActivityList.Query` |
| GET | `/{id}` | `GetActivityDetails.Query` |
| POST | `/` | `CreateActivity.Command` |
| PUT | `/` | `UpdateActivity.Command` |
| DELETE | `/{id}` | `DeleteActivity.Command` |

## Mapping

`IActivityMapper` has two methods:
- `ToActivity(CreateActivityRequest) → Activity`
- `UpdateActivity(Activity source, Activity destination)` — mutates destination in place

Injected into MediatR handlers via constructor DI.
