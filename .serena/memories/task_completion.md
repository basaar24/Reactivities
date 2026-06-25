# Task Completion Checklist

Run these after any coding change before considering the task done.

## Backend changes

```bash
cd backend
dotnet build          # Must pass — no warnings promoted to errors by default
```

No automated test runner is wired yet; integration tests live in `backend/Tests/IntegrationTests/` but check if they are runnable before assuming `dotnet test` works.

## Frontend changes

```bash
cd client
npm run build         # TypeScript compile + Vite bundle — must pass (strict mode)
npm run lint          # ESLint — must pass
npm run format:check  # Prettier — must pass (or run `npm run format` to fix)
```

## Both

- Verify the API still starts: `dotnet run --project API` in `backend/`.
- Verify the client still starts: `npm run dev` in `client/`.
- If database schema changed: run `dotnet ef migrations add <Name>` + `dotnet ef database update`.
