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

- Don't introduce a new state management library if one is already in use — this project already combines TanStack React Query (server state) with MobX (`client/src/lib/stores/`, e.g. `uiStore`, `counterStore`) for select local UI state; follow that existing split rather than reaching for Redux/Zustand/Context.
- Server state (API data) and client/UI state are different concerns — don't store fetched data in the same slice/context as purely local UI state unless the project already does this deliberately.
- Memoize (`useMemo`/`useCallback`/`React.memo`) only when there's an actual measured or clearly evident performance need — not by default on every value/function.

## Styling

- This project styles with MUI (Material UI) components and the `sx` prop, backed by Emotion (`@mui/material`, `@emotion/react`/`styled`) — use that consistently rather than introducing Tailwind, CSS Modules, or a separate styled-components layer.
- Check `client/package.json` for the installed MUI major version before relying on API specifics that changed across versions.

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

## Naming & structure

- Use descriptive, intention-revealing names for components, hooks, and variables (`useDebouncedSearch`, not `useThing`).
- Custom hooks start with `use` and follow the Rules of Hooks (no conditional hook calls, no hooks inside loops).
- Keep imports organized: external packages, then internal absolute imports, then relative imports — match whatever ESLint/import-order config the project already has rather than inventing a new order.

## Cleanup

- Remove unused imports, props, state, and dead code paths rather than leaving them commented out.
- Don't leave `console.log` debugging statements in committed code.
