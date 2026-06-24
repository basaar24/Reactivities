# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

### Backend (.NET 10)
```bash
cd backend
dotnet build                          # Build all projects
dotnet run --project API              # Start API server (https://localhost:5001)
dotnet ef migrations add <Name> --project Persistence --startup-project API
dotnet ef database update --project Persistence --startup-project API
```

### Frontend (React + Vite)
```bash
cd client
npm run dev           # Start dev server on https://localhost:3000
npm run build         # TypeScript compile + Vite bundle
npm run lint          # ESLint check
npm run format        # Prettier — rewrite all files
npm run format:check  # Prettier — check only (CI)
```

Both servers must run simultaneously for development. The API auto-seeds the SQLite database on startup.

## Architecture

This is a full-stack activity management app using **clean architecture** on the backend and **feature-based** structure on the frontend.

### Backend — Clean Architecture + CQRS

Four C# projects in `backend/Reactivities.slnx`:

| Project | Role |
|---|---|
| `API` | ASP.NET Core controllers; thin — delegates all logic to MediatR |
| `Application` | MediatR handlers (Queries + Commands) + request DTOs + AutoMapper profiles |
| `Domain` | `Activity` entity and core models; no dependencies |
| `Persistence` | EF Core `AppDbContext` with SQLite; migrations in `Persistence/Migrations/` |

Every API action follows the pattern: **Controller → MediatR → Handler → DbContext**. Controllers call `Mediator.Send()` and return the result directly.

**AutoMapper** (`Application/Core/Mappings/MappingProfiles.cs`) maps `CreateActivityRequest → Activity` and `Activity → Activity`. Registered in `Program.cs` via `AddAutoMapper`.

**Request DTOs** live in `Application/Activities/Requests/`. `CreateActivityRequest` is used for POST to keep validation attributes off the domain entity.

### Frontend — Feature-Based React

```
client/src/
├── app/
│   ├── layout/          # App shell: App.tsx (outlet wrapper), NavBar.tsx
│   ├── router/Routes.tsx # React Router v7 browser router definition
│   └── shared/components/MenuItemLink.tsx  # NavLink-wrapped MUI MenuItem
├── features/
│   ├── activities/      # Feature slices: dashboard/, details/, form/
│   └── home/HomePage.tsx
└── lib/
    ├── api/agent.tsx    # Axios instance; base URL from VITE_API_URL env var
    └── hooks/useActivities.tsx  # All React Query hooks for activities
```

**Routing** uses React Router v7 (`createBrowserRouter`). `App.tsx` is the root layout component rendering `<Outlet />`; it no longer holds local activity state.

**Server state** is managed entirely with TanStack React Query v5. The `useActivities` hook exposes queries and mutations; components do not call Axios directly.

**Route structure:**

| Path | Component |
|---|---|
| `/` | `HomePage` |
| `/activities` | `ActivityDashboard` |
| `/activities/:id` | `ActivityDetails` |
| `/createActivity` | `ActivityForm` (create mode) |
| `/manage/:id` | `ActivityForm` (edit mode) |

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
- **No global state manager**: routing replaced the `App.tsx` selected-activity / edit-mode local state. Navigation between views uses React Router instead of prop drilling.
- **Prettier + Husky**: `client/.prettierrc` enforces formatting (single quotes, no semis, 100-char width). Husky's pre-commit hook lives at `.husky/pre-commit` in the repo root (not inside `client/`) because `.git` is at the repo root. The hook runs `cd client && npx lint-staged`, which applies `eslint --fix` and `prettier --write` to staged `.ts`/`.tsx` files. The `prepare` script in `client/package.json` is `cd .. && husky` for the same reason.

## Analysis Protocol

### Graphify Codebase Analysis

## Step 1 — Load the graph report (always do this first)
Read graphify-out/GRAPH_REPORT.md before opening any source file.
Review: god nodes, community clusters, and surprising cross-module connections.
Use this graph data as the primary lens for all analysis below.

## Step 2 — Architecture overview
Summarise the project's main architecture in 10 concise points.
Ground every point in the graph (node degree, community membership, dependency edges).

## Step 3 — Critical modules & risk surface
Identify the most critical modules using graph metrics (god nodes, high betweenness centrality).
For each critical module, describe:
- Why it is critical (metric evidence)
- What breaks if it is changed
- Hidden ripple effects visible in the graph

## Step 4 — Audit plan
Propose a prioritised audit plan based on graph findings.
Order areas by risk, not by feature importance.
Flag any module with no inbound or outbound connections (orphans / dead code).

## Step 5 — Client-ready report
Produce a structured report with these five sections:
1. General architecture — high-level summary for a non-technical stakeholder
2. Technical risks — graph-evidenced risks ranked by severity
3. Undocumented areas — modules or flows with missing or thin documentation
4. Critical dependencies — external libs or internal god nodes the system cannot function without
5. Quick wins — low-effort, high-impact improvements (refactors, docs, tests)

---
Constraint: do not open individual source files until Steps 1–3 are complete.
All claims must reference graph evidence (node name, metric, community ID).
