# Reactivities — Project Core

Full-stack activity management app. Monorepo with two independently runnable sub-projects.

## Layout

```
backend/          # .NET 10 clean-architecture API (solution: Reactivities.slnx)
client/           # React 19 + TypeScript frontend (Vite)
docs/             # Architecture standards, API spec, data model
openspec/         # Structured change proposals (changes/, specs/, config.yaml)
graphify-out/     # Pre-built knowledge graph (GRAPH_REPORT.md is the entry point)
```

## Sub-project memories

- Backend architecture, patterns, and invariants: `mem:backend/core`
- Frontend architecture and patterns: `mem:frontend/core`
- Full tech stack details: `mem:tech_stack`
- Coding conventions: `mem:conventions`
- Task completion checklist: `mem:task_completion`
- Dev/run commands: `mem:suggested_commands`

## Project-wide invariants

- Both servers must run simultaneously for development (API on :5001, client on :3000).
- HTTPS required locally (self-signed certs via vite-plugin-mkcert for client; .NET dev cert for API).
- SQLite database (`backend/API/reactivities.db`) is auto-seeded on first run — no manual seed step.
- Active OpenSpec change: `openspec/changes/migrate-automapper-to-custommapper` (in-progress migration from AutoMapper to custom `IActivityMapper`).
- Standards docs live in `docs/`: `backend-standards.md`, `frontend-standards.md`, `base-standards.md`, `api-spec.yml`.
