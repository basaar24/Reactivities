# Tech Stack

## Backend

| Layer | Technology |
|---|---|
| Runtime | .NET 10, C# 13 |
| Web framework | ASP.NET Core Web API |
| CQRS / mediator | MediatR 12.5.0 |
| ORM | Entity Framework Core 10 |
| Database | SQLite (file: `backend/API/reactivities.db`) |
| Object mapping | Custom `IActivityMapper` (replaced AutoMapper) |
| DI | Microsoft.Extensions.DependencyInjection (built-in) |

AutoMapper was removed; mapping is now via `Application.Core.IActivityMapper` / `ActivityMapper`.

## Frontend

| Concern | Library / Version |
|---|---|
| UI framework | React 19 |
| Language | TypeScript ~6.0 (strict mode) |
| Build tool | Vite 8 |
| Component library | MUI v9 (`@mui/material`) |
| Server state | TanStack React Query v5 |
| Client state | MobX 6 + mobx-react-lite |
| Routing | React Router v7 |
| HTTP client | Axios 1.x |
| Linting | ESLint 10 (flat config) |
| Formatting | Prettier 3 |
| Git hooks | Husky 9 + lint-staged |
| Date utilities | date-fns 4 |
