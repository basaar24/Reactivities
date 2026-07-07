---
paths: ["**/*.ts", "**/*.tsx"]
---

# React + TypeScript Rules

## TypeScript strictness
- TypeScript only — never drop to plain `.js`/`.jsx` for new files in this project.
- Never use `any` unless there is genuinely no better option; if used, add a one-line comment justifying it and prefer `unknown` + narrowing instead.
- Do not suppress type errors with `@ts-ignore` / `@ts-expect-error` as a way to move on — fix the underlying type issue. If a suppression is truly necessary (e.g., a bad third-party type definition), comment why.
- Keep `strict` mode on in tsconfig; don't add compiler flags that loosen it to make an error go away.
- Prefer `interface` for object shapes that might be extended, `type` for unions/intersections/utility compositions — stay consistent with whichever the codebase already predominantly uses.

## Component design
- Function components with hooks only; no class components in new code.
- Keep components focused — extract a subcomponent or custom hook once a component is doing more than one clear thing (e.g., data fetching + heavy rendering + form logic all in one file).
- Co-locate a component's types with the component unless they're shared, in which case lift them to a shared `types/` module.
- No prop drilling more than 2-3 levels deep — reach for context or a state library the project already uses instead.

## State & data
- Server state (all API/backend data) goes through TanStack Query — don't duplicate it into MobX stores or component state as a second cache.
- Local/UI state (modals, form step, hover/focus state, etc.) belongs in a MobX store or `useLocalObservable`, not component `useState` duplicating the same value — pick one owner per piece of state.
- Wrap components that read observable state in `observer()`; a component that silently doesn't re-render when a MobX value changes is almost always a missing `observer()`.
- Keep MobX mutations inside explicit actions (`action`/`runInAction`) rather than mutating observables from arbitrary call sites.
- Use hierarchical, array-based TanStack Query keys (`['orders', orderId]`) so invalidation can target a whole resource or one item.
- Invalidate via `queryClient.invalidateQueries` after mutations rather than hand-patching the cache, unless an optimistic update is specifically warranted — and if you do an optimistic update, handle the rollback path on error.
- Handle `isLoading`, `isError`, and empty-data cases explicitly in the component — never assume `data` is defined just because the query "usually" succeeds.
- Memoize (`useMemo`/`useCallback`/`React.memo`) only when there's an actual measured or clearly evident performance need — not by default on every value/function.

## Routing (React Router v7)
- Follow whichever mode the project has adopted (framework/data mode with loaders & actions, vs. declarative mode) consistently — don't mix data-loading patterns across routes.
- If the project uses loaders/actions, do data fetching there rather than duplicating it in a `useEffect` inside the route component.

## React 19 patterns
- No need for `forwardRef` for simple ref forwarding — `ref` can be passed as a regular prop on function components now.
- Prefer the newer form/action primitives (`useActionState`, `useOptimistic`, form Actions) over manual `useState`+`useEffect` submission-state plumbing where the codebase has already adopted them — don't introduce them as a one-off if the rest of the code still uses the older pattern.

## Styling (MUI)
- Use the `sx` prop or `styled()` for one-off styling; put repeated/global style decisions (spacing scale, palette, typography) in theme overrides (`createTheme`) rather than duplicating the same `sx` object across files.
- Pull values from the theme (`theme.spacing()`, `theme.palette.*`) instead of hardcoding pixel values or hex codes.
- Compose/extend MUI components rather than wrapping every single one in a custom component — a wrapper needs to add real behavior or a11y fix to justify itself, not just rename a prop.

## Accessibility & UX states
- Use semantic HTML elements (`button`, `nav`, `label`, etc.) over generic `div`/`span` with click handlers; add ARIA attributes only when semantic HTML genuinely can't express the pattern.
- Interactive elements must be keyboard-operable (focus states, `Enter`/`Space` activation) — don't rely on `onClick` alone on non-native elements.
- Images need meaningful `alt` text (or explicitly empty `alt=""` for decorative images).
- Every async data view handles loading, error, and empty states explicitly — don't leave a component that only renders correctly on the happy path.
- Wrap route-level or otherwise risky subtrees in an error boundary so a render-time failure doesn't blank the whole app.

## Security
- Never store auth tokens or sensitive data in `localStorage`/`sessionStorage` if the project's auth pattern uses httpOnly cookies or in-memory storage instead — follow the existing pattern rather than introducing a new storage mechanism.
- Avoid `dangerouslySetInnerHTML`; if unavoidable (e.g., rendering CMS content), sanitize the HTML first.

## Lists
- Use a stable unique id as the `key` prop for list items, never the array index, when the list can be reordered, filtered, or have items inserted/removed.

## Testing
- New components with meaningful logic (not pure presentational wrappers) get a test using the project's existing test setup (React Testing Library, Vitest/Jest, etc.).
- Test behavior (what the user sees/does), not implementation details (internal state, private methods).
- Don't leave a failing or skipped test in place without flagging it explicitly.
- If the project already has an accessibility test tool set up (e.g. jest-axe), run it against new interactive components rather than relying on manual review alone.

## Naming & structure
- Use descriptive, intention-revealing names for components, hooks, and variables (`useDebouncedSearch`, not `useThing`).
- Custom hooks start with `use` and follow the Rules of Hooks (no conditional hook calls, no hooks inside loops).
- Keep imports organized: external packages, then internal absolute imports, then relative imports — match whatever ESLint/import-order config the project already has rather than inventing a new order.
- Follow the file naming convention already established in the repo (many React/TS projects use kebab-case, e.g. `user-profile.tsx`) — check existing files before assuming.

## Cleanup
- Remove unused imports, props, state, and dead code paths rather than leaving them commented out.
- Don't leave `console.log` debugging statements in committed code.
