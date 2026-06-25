# Frontend — Core

## Project Structure

```
client/src/
├── app/
│   ├── layout/
│   │   ├── App.tsx             # Root layout — renders <Outlet /> only (no local state)
│   │   └── NavBar.tsx
│   ├── router/Routes.tsx       # createBrowserRouter definition
│   └── shared/components/
│       └── MenuItemLink.tsx    # NavLink-wrapped MUI MenuItem
├── features/
│   └── activities/
│       ├── dashboard/          # ActivityDashboard, ActivityList, ActivityCard, ActivityFilters
│       ├── details/            # ActivityDetailsPage + sub-components
│       └── form/               # ActivityForm (create + edit mode)
└── lib/
    ├── api/agent.tsx           # Axios instance; base URL from VITE_API_URL; 1s artificial delay
    └── hooks/useActivities.tsx # All React Query hooks — single source of truth for API calls
```

## Route table

| Path | Component |
|---|---|
| `/` | `HomePage` |
| `/activities` | `ActivityDashboard` |
| `/activities/:id` | `ActivityDetails` |
| `/createActivity` | `ActivityForm` (create mode) |
| `/manage/:id` | `ActivityForm` (edit mode) |

## Data flow

- Server state: TanStack React Query v5 via `useActivities` hook.
- `["activities"]` cache key invalidated after create/update/delete mutations.
- No component imports `agent.tsx` directly; all calls go through `useActivities`.
- Client state (if needed): MobX stores, but React Query handles the server layer.

## Environment

- `VITE_API_URL` in `client/.env.development` = `https://localhost:5001/api`
- Vite mkcert plugin generates self-signed certs for HTTPS on :3000.
