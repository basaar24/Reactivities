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
        ├── app/layout/           # App shell and navigation
        ├── features/activities/  # Activity UI (dashboard, details, form)
        └── lib/                  # Axios agent and React Query hooks
```

## 🏗️ Architecture

The backend follows **clean architecture** with the CQRS pattern via MediatR. Controllers are thin — they forward requests to MediatR handlers which contain all business logic.

The frontend uses **TanStack React Query** for all server state (fetching, caching, mutations). Components interact with the API exclusively through the `useActivities` custom hook.
