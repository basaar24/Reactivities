# Development Guide

This guide provides step-by-step instructions for setting up the Reactivities development environment and running both the backend and frontend.

## Prerequisites

Ensure you have the following installed:
- **.NET 10 SDK** — [download](https://dotnet.microsoft.com/download/dotnet/10.0)
- **Node.js 20+** and **npm**
- **Git**

No Docker or external database required — the backend uses SQLite and auto-creates/migrates/seeds the database on first startup.

## 1. Clone the Repository

```bash
git clone <repo-url>
cd Reactivities
```

## 2. Backend Setup

```bash
cd backend

# Verify the solution builds
dotnet build

# Start the API server — auto-migrates and seeds the SQLite database on first run
dotnet run --project API
```

The API is available at `https://localhost:5001`. The SQLite database file (`reactivities.db`) is created automatically in the `backend/API` directory. On first run, `DbInitializer.SeedData()` inserts 9 sample activities if the database is empty.

## 3. Frontend Setup

Open a second terminal:

```bash
cd client

# Install dependencies
npm install

# Start the Vite dev server
npm run dev
```

The app is available at `https://localhost:3000`. Vite uses `vite-plugin-mkcert` for self-signed HTTPS certificates — trust the certificate if your browser warns.

Both the backend (port 5001) and the frontend (port 3000) must run simultaneously for the app to work.

## 4. Environment Configuration

The frontend reads `VITE_API_URL` from environment files:

**`client/.env.development`** (already committed):
```env
VITE_API_URL=https://localhost:5001/api
```

The backend does not require an `.env` file for local development — the SQLite connection string is configured in `backend/API/appsettings.Development.json`.

## 5. Code Quality

```bash
# Backend — must produce zero errors
cd backend && dotnet build

# Frontend — ESLint
cd client && npm run lint

# Frontend — Prettier check (no writes)
cd client && npm run format:check

# Frontend — Prettier rewrite all files
cd client && npm run format
```

Pre-commit hooks (Husky + lint-staged) run `eslint --fix` and `prettier --write` on staged `.ts`/`.tsx` files automatically.

## 6. EF Core Migrations

When the `Activity` entity changes, create and apply a new migration:

```bash
cd backend

# Add migration
dotnet ef migrations add <MigrationName> --project Persistence --startup-project API

# Apply to local SQLite database
dotnet ef database update --project Persistence --startup-project API
```

## 7. Manual API Testing

With the backend running on `https://localhost:5001`, test endpoints with curl (the `-k` flag skips cert verification for self-signed certs):

```bash
# List all activities
curl -k https://localhost:5001/api/activities

# Get single activity (replace <id> with a real GUID from the list)
curl -k https://localhost:5001/api/activities/<id>

# Create an activity (returns the new GUID)
curl -k -X POST https://localhost:5001/api/activities \
  -H "Content-Type: application/json" \
  -d '{"title":"Test","date":"2026-09-01T10:00:00","description":"Test desc","category":"drinks","city":"London","venue":"Pub","latitude":51.5,"longitude":-0.1}'

# Update an activity (204 No Content)
curl -k -X PUT https://localhost:5001/api/activities \
  -H "Content-Type: application/json" \
  -d '{"id":"<id>","title":"Updated","date":"2026-09-01T10:00:00","description":"Updated desc","category":"culture","isCancelled":false,"city":"Paris","venue":"Museum","latitude":48.8,"longitude":2.3}'

# Delete an activity (200 OK)
curl -k -X DELETE https://localhost:5001/api/activities/<id>
```

## 8. Build for Production

```bash
# Backend
cd backend && dotnet publish API -c Release

# Frontend
cd client && npm run build
```

The frontend build output is in `client/dist/`. TypeScript compile errors fail the build — resolve all type errors before publishing.
