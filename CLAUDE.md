# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

### Backend (.NET 10)
```bash
dotnet build                          # Build all projects
dotnet run --project API              # Start API server (https://localhost:5001)
dotnet ef migrations add <Name> --project Persistence --startup-project API
dotnet ef database update --project Persistence --startup-project API
```

### Frontend (React + Vite)
```bash
cd client
npm run dev      # Start dev server on https://localhost:3000
npm run build    # TypeScript compile + Vite bundle
npm run lint     # ESLint check
```

Both servers must run simultaneously for development. The API auto-seeds the SQLite database on startup.

## Architecture

This is a full-stack activity management app using **clean architecture** on the backend and **feature-based** structure on the frontend.

### Backend — Clean Architecture + CQRS

Four C# projects in `Reactivities.slnx`:

| Project | Role |
|---|---|
| `API` | ASP.NET Core controllers; thin — delegates all logic to MediatR |
| `Application` | MediatR handlers (Queries + Commands); business logic lives here |
| `Domain` | `Activity` entity and core models; no dependencies |
| `Persistence` | EF Core `AppDbContext` with SQLite; migrations in `Persistence/Migrations/` |

Every API action follows the pattern: **Controller → MediatR → Handler → DbContext**. Controllers call `Mediator.Send()` and return the result directly.

### Frontend — Feature-Based React

```
client/src/
├── app/layout/          # App shell: App.tsx (root state), NavBar.tsx
├── features/activities/ # Feature slices: dashboard/, details/, form/
└── lib/
    ├── api/agent.tsx    # Axios instance; base URL from VITE_API_URL env var
    └── hooks/useActivities.tsx  # All React Query hooks for activities
```

**Server state** is managed entirely with TanStack React Query v5. The `useActivities` hook exposes queries and mutations; components do not call Axios directly.

**Local UI state** (selected activity, edit mode) lives in `App.tsx` and is passed down as props — no global state manager.

### API Routes

Base path: `/api/activities`

| Method | Path | Handler |
|---|---|---|
| GET | `/` | `GetActivityList.Query` |
| GET | `/{id}` | `GetActivityDetails.Query` |
| POST | `/` | `CreateActivity.Command` |
| PUT | `/` | `UpdateActivity.Command` |
| DELETE | `/{id}` | `DeleteActivity.Command` |

## Key Decisions

- **React Query cache invalidation**: after create/update/delete mutations, the `["activities"]` query is invalidated to refetch the list.
- **Axios interceptor**: adds a 1-second artificial delay in `agent.tsx` — intentional for UX loading state testing.
- **HTTPS required locally**: Vite uses `vite-plugin-mkcert` for self-signed certs. The `.env.development` sets `VITE_API_URL=https://localhost:5001/api`.
- **TypeScript strict mode**: no implicit `any`, no unused locals/parameters — the build will fail on type errors.
- **Database seeding**: `DbInitializer.SeedData()` runs on every startup if the database is empty; no manual seed step needed.
