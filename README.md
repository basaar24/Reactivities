# 🎯 Reactivities

A full-stack activity management app built with **React 19 + TypeScript** on the frontend and **ASP.NET Core 10** on the backend, following clean architecture principles.

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| 🎨 Frontend | React 19, TypeScript, Vite, Material UI |
| 🔄 State / Data | TanStack React Query v5, Axios |
| ⚙️ Backend | ASP.NET Core 10, MediatR (CQRS) |
| 🗄️ Database | SQLite via Entity Framework Core 10 |

## 🚀 Getting Started

### Prerequisites
- 🔷 [.NET 10 SDK](https://dotnet.microsoft.com/download)
- 🟩 [Node.js](https://nodejs.org/) (LTS)

### Running the app

**⚙️ Backend** (from repo root):
```bash
dotnet run --project API
```
API runs at `https://localhost:5001`. The database is created and seeded automatically on first run.

**🎨 Frontend** (in a separate terminal):
```bash
cd client
npm install
npm run dev
```
App runs at `https://localhost:3000`.

## 📁 Project Structure

```
Reactivities/
├── API/          # ASP.NET Core controllers
├── Application/  # MediatR CQRS handlers (business logic)
├── Domain/       # Core entities
├── Persistence/  # EF Core DbContext + migrations
└── client/       # React + Vite frontend
    └── src/
        ├── app/
        │   ├── layout/           # App.tsx (root layout) + NavBar.tsx
        │   ├── router/           # React Router v7 route definitions
        │   └── shared/           # Shared UI components (MenuItemLink)
        ├── features/
        │   ├── activities/       # dashboard/, details/, form/
        │   └── home/             # HomePage
        └── lib/
            ├── api/              # Axios instance (agent.tsx)
            ├── hooks/            # useActivities React Query hooks
            └── types/            # Shared TypeScript types
```

## 🗺️ Routes

| Path | Component | Notes |
|---|---|---|
| `/` | `HomePage` | Landing page |
| `/activities` | `ActivityDashboard` | List all activities |
| `/activities/:id` | `ActivityDetails` | Read-only detail view |
| `/createActivity` | `ActivityForm` | Create mode |
| `/manage/:id` | `ActivityForm` | Edit mode |

## 🧹 Code Quality

| Tool | Purpose |
|---|---|
| ESLint 10 (flat config) | Linting — TypeScript + React rules |
| Prettier 3 | Formatting — enforced via pre-commit |
| Husky 9 | Git hooks runner |
| lint-staged | Scopes pre-commit checks to staged files only |

```bash
cd client
npm run lint          # ESLint check
npm run format        # Prettier — format all files
npm run format:check  # Prettier — check without writing (CI)
```

On every `git commit`, Husky runs lint-staged which applies `eslint --fix` and `prettier --write` to staged `.ts`/`.tsx` files automatically.

## 🏗️ Architecture

**Backend** follows clean architecture with the CQRS pattern via MediatR. Controllers are thin — they delegate all logic to MediatR handlers via `Mediator.Send()`.

**Frontend** uses React Router v7 for navigation (no local state in `App.tsx`) and TanStack React Query v5 for all server state. Components interact with the API exclusively through the `useActivities` hook — never calling Axios directly.

**API routes** are all under `/api/activities` and support GET list, GET by id, POST, PUT, and DELETE.
