# Suggested Commands

## Backend (run from repo root or `backend/`)

```bash
cd backend
dotnet build                                                          # Build all projects
dotnet run --project API                                              # Start API on https://localhost:5001
dotnet ef migrations add <Name> --project Persistence --startup-project API
dotnet ef database update --project Persistence --startup-project API
```

## Frontend (run from `client/`)

```bash
cd client
npm run dev            # Dev server on https://localhost:3000
npm run build          # tsc -b && vite build (fails on type errors)
npm run lint           # ESLint check
npm run format         # Prettier — rewrite all files
npm run format:check   # Prettier — check only (CI)
```

## Windows-specific notes

- Use PowerShell or Git Bash. Path separator is `\` in Explorer but `/` works in bash tools.
- `cd backend && dotnet ...` or `cd client && npm ...` — always `cd` first; commands are not cross-directory.
- The `prepare` script in `client/package.json` runs `cd .. && husky` to install hooks from the repo root (where `.git` lives), not from `client/`.
