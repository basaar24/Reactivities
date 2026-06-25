# Conventions

## Backend (C#)

- **CQRS**: Every feature is a self-contained nested-class pair `Query`/`Command` + `Handler` inside a single file (e.g. `GetActivityList.cs`). No standalone handler files.
- **Controllers are thin**: No business logic. Controllers call `Mediator.Send()` and return the result directly.
- **Dependency rule**: Domain → none; Persistence → Domain; Application → Domain + Persistence; API → Application + Persistence. Never invert.
- **Mapping**: Use `IActivityMapper` (injected via DI) — NOT AutoMapper. `ActivityMapper` is the sole implementation, registered as `AddScoped<IActivityMapper, ActivityMapper>()`.
- **DTOs**: `CreateActivityRequest` (and similar) live in `Application/Activities/Requests/`. Never put validation attributes on domain entities.
- **Nullable**: `<Nullable>enable</Nullable>` in all projects; all references must be null-safe.

## Frontend (TypeScript / React)

- **Strict TypeScript**: `strict: true`; build fails on type errors. No implicit `any`, no unused locals/parameters.
- **No direct Axios calls in components**: All HTTP goes through hooks in `lib/hooks/useActivities.tsx`.
- **React Query for server state**: Mutations invalidate `["activities"]` cache key after create/update/delete.
- **No global state manager** for routing: Use React Router navigation instead of prop drilling or local state.
- **MobX** is installed but used selectively for client-only state (not server state — that's React Query).
- **Prettier config** (`client/.prettierrc`): `semi: false`, `singleQuote: true`, `tabWidth: 2`, `trailingComma: "es5"`, `printWidth: 100`.
- **Husky pre-commit**: Runs `eslint --fix` + `prettier --write` on staged `.ts`/`.tsx` files. Hook at repo root `.husky/pre-commit`.
- **Axios artificial delay**: 1-second delay in `lib/api/agent.tsx` — intentional for UX loading state testing. Do not remove.

## OpenSpec workflow

Active changes live in `openspec/changes/<name>/`. Each change has `proposal.md`, `design.md`, `specs/`, and `tasks.md`. Specs in `openspec/specs/` are the canonical reference; delta specs in a change directory override them during that change.
