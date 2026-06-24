# Frontend Standards

This document defines development standards, architecture patterns, and coding conventions for the Reactivities frontend — a React 19 / TypeScript application built with Vite, MUI, TanStack React Query, and MobX.

## Technology Stack

| Concern | Library / Version |
|---|---|
| UI framework | React 19 |
| Language | TypeScript 6 (strict mode) |
| Build tool | Vite 8 |
| Component library | MUI v9 (`@mui/material`) |
| Server state | TanStack React Query v5 |
| Client state | MobX 6 |
| Routing | React Router v7 |
| HTTP client | Axios 1.x |
| Linting | ESLint 10 (flat config) |
| Formatting | Prettier 3 |
| Git hooks | Husky 9 + lint-staged |

---

## Project Structure

```
client/src/
├── app/
│   ├── layout/
│   │   ├── App.tsx             # Root layout — renders <Outlet /> only
│   │   └── NavBar.tsx          # Top navigation bar
│   ├── router/
│   │   └── Routes.tsx          # createBrowserRouter definition
│   └── shared/
│       └── components/
│           └── MenuItemLink.tsx # NavLink-wrapped MUI MenuItem
├── features/
│   ├── activities/
│   │   ├── dashboard/          # ActivityDashboard, ActivityList, ActivityCard, ActivityFilters
│   │   ├── details/            # ActivityDetailsPage, Header, Info, Chat, Sidebar
│   │   └── form/
│   │       └── ActivityForm.tsx  # Create / edit form (mode determined by presence of id param)
│   └── home/
│       └── HomePage.tsx
└── lib/
    ├── api/
    │   └── agent.ts            # Axios instance; base URL from VITE_API_URL
    ├── hooks/
    │   └── useActivities.ts    # All React Query queries and mutations
    ├── stores/
    │   └── uiStore.ts          # MobX store for loading state (isBusy / isIdle)
    └── types/
        └── index.d.ts          # Global TypeScript ambient types
```

---

## Routing

Defined in `client/src/app/router/Routes.tsx` using `createBrowserRouter`:

| Path | Component | Purpose |
|---|---|---|
| `/` | `HomePage` | Landing page |
| `/activities` | `ActivityDashboard` | Activity list + filters |
| `/activities/:id` | `ActivityDetailsPage` | Single activity detail |
| `/createActivity` | `ActivityForm` | Create new activity |
| `/manage/:id` | `ActivityForm` | Edit existing activity |
| `/counter` | `Counter` | Demo counter |

`App.tsx` is the root layout component — it renders `<Outlet />` and the `<NavBar />`. It holds no local state.

Use `useNavigate()` from React Router for programmatic navigation. Forms redirect to `/activities/:id` on successful submit.

---

## Data Fetching — React Query

All server state lives in React Query. **Never import `agent` directly in feature components.** All API access goes through the `useActivities` hook.

### `useActivities(id?: string)`

Located at `client/src/lib/hooks/useActivities.ts`.

```typescript
const {
  activities,        // Activity[] — list query result
  isPending,         // boolean — list loading state
  activity,          // Activity — detail query result
  isLoadingActivity, // boolean — detail loading state
  createActivity,    // UseMutationResult — POST /activities
  updateActivity,    // UseMutationResult — PUT /activities
  deleteActivity,    // UseMutationResult — DELETE /activities/:id
} = useActivities(id)
```

**Query keys**:
- List: `['activities']`
- Detail: `['activities', id]`

All mutations invalidate `['activities']` on success, which triggers a refetch of the list.

**Conditionally enabled**:
- The list query is only enabled when `id` is absent and the current path is `/activities`.
- The detail query is only enabled when `id` is truthy.

---

## HTTP Client — Axios

`client/src/lib/api/agent.ts` exports a configured Axios instance:

- **Base URL**: `import.meta.env.VITE_API_URL` (set to `https://localhost:5001/api` in `.env.development`)
- **Request interceptor**: calls `store.uiStore.isBusy()` on every outgoing request
- **Response interceptor**: awaits `sleep(1000)` (intentional 1-second delay for UX loading state testing), then calls `store.uiStore.isIdle()`

The artificial delay is intentional — do not remove it without updating loading state UX.

---

## Client State — MobX

MobX is used only for UI-level state not tied to server data. Currently:

- **`uiStore`**: tracks a loading counter (`isBusy` / `isIdle`) driven by the Axios interceptors

Do not use MobX for server data — that is React Query's responsibility.

---

## Component Conventions

- **Functional components only** — no class components.
- **PascalCase filenames** for component files (e.g., `ActivityCard.tsx`).
- **camelCase filenames** for non-component files (hooks, utilities, types).
- Props typed inline or via a local `type Props = { ... }` — no `interface` for simple prop shapes.
- No anonymous default exports: `export default function ActivityCard(...)` is preferred over `const Foo = () => {}; export default Foo`.
- One component per file.

### MUI Usage

- Use MUI Grid v2 API (no `item` prop; use `size` prop instead).
- Prefer the `sx` prop over `className` or inline `style` for MUI components.
- Standard dashboard layout: 8/4 Grid split (main content left, sidebar right).

---

## TypeScript

- **`strict: true`** in `tsconfig.json` — no implicit `any`, no unused locals, no unused parameters.
- `npm run build` (which runs `tsc -b` then Vite bundle) fails on any type error — fix before committing.
- Global ambient types live in `client/src/lib/types/index.d.ts` (no `export` keyword — they are global).

```typescript
// Activity type (global ambient)
type Activity = {
  id: string
  title: string
  date: string       // ISO 8601 string, not Date object
  description: string
  category: string
  isCancelled: boolean
  city: string
  venue: string
  latitude: number
  longitude: number
}
```

---

## Naming Conventions

| Element | Convention | Example |
|---|---|---|
| Component files | PascalCase | `ActivityCard.tsx` |
| Non-component files | camelCase | `useActivities.ts`, `agent.ts` |
| React hooks | `use` prefix, camelCase | `useActivities`, `useNavigate` |
| MobX store files | camelCase + `Store` suffix | `uiStore.ts` |
| CSS / MUI styles | `sx` prop with object literal | `sx={{ mb: 2 }}` |

---

## Code Quality

### ESLint

Flat config at `client/eslint.config.js`. Extends:
- `@eslint/js` recommended
- `typescript-eslint` recommended
- `eslint-plugin-react-hooks` recommended
- `eslint-plugin-react-refresh` vite
- `eslint-config-prettier` (last — disables all formatting rules)

```bash
cd client && npm run lint
```

### Prettier

Config in `client/.prettierrc`:
```json
{
  "semi": false,
  "singleQuote": true,
  "tabWidth": 2,
  "trailingComma": "es5",
  "printWidth": 100,
  "endOfLine": "auto"
}
```

```bash
cd client && npm run format:check   # check only
cd client && npm run format         # rewrite all files
```

### Husky + lint-staged

The pre-commit hook lives at `.husky/pre-commit` in the repo root (not inside `client/`) because `.git` is at the root. The hook runs `cd client && npx lint-staged`, which applies `eslint --fix` and `prettier --write` to staged `.ts`/`.tsx` files.

---

## Environment Variables

| Variable | File | Value |
|---|---|---|
| `VITE_API_URL` | `client/.env.development` | `https://localhost:5001/api` |

Vite only exposes variables prefixed with `VITE_`. Access them via `import.meta.env.VITE_API_URL`.

---

## Build

```bash
cd client
npm run build    # tsc -b && vite build — fails on type errors
```

Output goes to `client/dist/`. All TypeScript errors must be resolved before the build succeeds.
