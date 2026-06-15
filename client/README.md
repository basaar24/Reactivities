# 🎯 Reactivities — React Client

React + TypeScript + Vite frontend for the Reactivities activity management app.

## 🛠️ Tech Stack

| Library                        | Purpose                      |
| ------------------------------ | ---------------------------- |
| ⚛️ React 19 + TypeScript       | UI framework                 |
| ⚡ Vite + `vite-plugin-mkcert` | Dev server with local HTTPS  |
| 🔀 React Router v7             | Client-side routing          |
| 🔄 TanStack React Query v5     | Server state / data fetching |
| 🎨 MUI (Material UI)           | Component library            |
| 🌐 Axios                       | HTTP client                  |

## 🚀 Getting Started

```bash
npm install
npm run dev      # https://localhost:3000
npm run build    # TypeScript compile + Vite bundle
npm run lint     # ESLint check
```

The API must be running at `https://localhost:5001` (set in `.env.development` via `VITE_API_URL`).

## 📁 Project Structure

```
src/
├── app/
│   ├── layout/
│   │   ├── App.tsx              # Root layout — renders <Outlet />
│   │   └── NavBar.tsx           # Top nav bar with route links
│   ├── router/
│   │   └── Routes.tsx           # createBrowserRouter route definitions
│   └── shared/components/
│       └── MenuItemLink.tsx     # NavLink-wrapped MUI MenuItem
├── features/
│   ├── activities/
│   │   ├── dashboard/           # ActivityDashboard, ActivityList, ActivityCard
│   │   ├── details/             # ActivityDetails
│   │   └── form/                # ActivityForm (create + edit)
│   └── home/
│       └── HomePage.tsx
└── lib/
    ├── api/agent.tsx            # Axios instance (1s artificial delay interceptor)
    ├── hooks/useActivities.tsx  # All React Query hooks
    └── types/index.d.ts         # Shared TypeScript types
```

## 🗺️ Routes

| Path              | Component           | Notes                     |
| ----------------- | ------------------- | ------------------------- |
| `/`               | `HomePage`          | 🏠 Landing page           |
| `/activities`     | `ActivityDashboard` | 📋 List of all activities |
| `/activities/:id` | `ActivityDetails`   | 🔍 Read-only detail view  |
| `/createActivity` | `ActivityForm`      | ✏️ Create mode            |
| `/manage/:id`     | `ActivityForm`      | 🛠️ Edit mode              |

## 🧠 State Management

- 🔄 **Server state** — TanStack React Query v5 via `useActivities` hook. Components never call Axios directly.
- 🚫 **No global client state** — navigation between views uses React Router; there is no Redux or Zustand.
- ♻️ **Cache invalidation** — create/update/delete mutations invalidate the `["activities"]` query key to trigger a refetch.
