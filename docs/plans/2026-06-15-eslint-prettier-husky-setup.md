# ESLint + Prettier + Husky Setup Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Add Prettier formatting, ESLint-Prettier integration, and Husky pre-commit hooks to the existing React/TypeScript client app.

**Architecture:** Prettier handles formatting; `eslint-config-prettier` disables conflicting ESLint rules; `lint-staged` scopes pre-commit checks to changed files only; Husky wires the git pre-commit hook to lint-staged.

**Tech Stack:** ESLint 10 (flat config), Prettier 3, Husky 9, lint-staged, TypeScript 6, Vite 8

**Working directory for all commands:** `client/`

> **Note:** `.husky/pre-commit` lives at the **repo root** (not inside `client/`) because `.git` is at the repo root. The hook runs `cd client && npx lint-staged`. The `prepare` script in `client/package.json` is `cd .. && husky` for the same reason.

---

## File Map

| File | Action | Purpose |
|---|---|---|
| `client/package.json` | Modify | Add `format`, `format:check`, `prepare` scripts; add `lint-staged` config |
| `client/eslint.config.js` | Modify | Import and append `eslint-config-prettier` at end of extends |
| `client/.prettierrc` | Create | Prettier formatting rules |
| `client/.prettierignore` | Create | Tell Prettier what to skip |
| `.husky/pre-commit` | Create at repo root | Run `lint-staged` on commit |

---

## Task 1: Install Prettier and ESLint-Prettier integration

**Files:** `client/package.json` (devDependencies updated automatically)

- [ ] **Step 1: Install packages**

```bash
cd client
npm install --save-dev prettier eslint-config-prettier
```

Expected output: packages added, `package-lock.json` updated.

- [ ] **Step 2: Verify installation**

```bash
npx prettier --version
```

Expected: prints a version like `3.x.x`

---

## Task 2: Create Prettier config files

**Files:**
- Create: `client/.prettierrc`
- Create: `client/.prettierignore`

- [ ] **Step 1: Create `client/.prettierrc`**

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

- [ ] **Step 2: Create `client/.prettierignore`**

```
dist
node_modules
*.lock
```

- [ ] **Step 3: Verify Prettier works on a file**

```bash
cd client
npx prettier --check src/main.tsx
```

Expected: either "All matched files use Prettier code style!" or a diff — both confirm Prettier can parse the file.

---

## Task 3: Update ESLint config to disable conflicting rules

**Files:** Modify `client/eslint.config.js`

- [ ] **Step 1: Add `eslint-config-prettier` import and extend it last**

Replace the full content of `client/eslint.config.js` with:

```js
import js from '@eslint/js'
import globals from 'globals'
import reactHooks from 'eslint-plugin-react-hooks'
import reactRefresh from 'eslint-plugin-react-refresh'
import tseslint from 'typescript-eslint'
import { defineConfig, globalIgnores } from 'eslint/config'
import eslintConfigPrettier from 'eslint-config-prettier'

export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      js.configs.recommended,
      tseslint.configs.recommended,
      reactHooks.configs.flat.recommended,
      reactRefresh.configs.vite,
      eslintConfigPrettier,   // must be last — disables all formatting rules
    ],
    languageOptions: {
      globals: globals.browser,
    },
  },
])
```

- [ ] **Step 2: Verify ESLint still passes**

```bash
cd client
npm run lint
```

Expected: no errors.

---

## Task 4: Add format scripts to package.json

**Files:** Modify `client/package.json` — `scripts` section only.

- [ ] **Step 1: Add `format` and `format:check` scripts**

```json
"scripts": {
  "dev": "vite",
  "build": "tsc -b && vite build",
  "lint": "eslint .",
  "format": "prettier --write .",
  "format:check": "prettier --check .",
  "preview": "vite preview",
  "prepare": "cd .. && husky"
},
```

> `prepare` points to the repo root because `.git` lives there, not in `client/`.

- [ ] **Step 2: Verify format script works**

```bash
cd client
npm run format:check
```

Expected: exits cleanly or lists files needing formatting.

---

## Task 5: Install Husky and lint-staged

**Files:** `client/package.json` (devDependencies)

- [ ] **Step 1: Install packages**

```bash
cd client
npm install --save-dev husky lint-staged
```

Expected: packages added.

---

## Task 6: Create the Husky pre-commit hook at repo root

**Files:** Create `.husky/pre-commit` at the repo root (not inside `client/`)

- [ ] **Step 1: Create the hook file**

Create `.husky/pre-commit`:

```sh
cd client && npx lint-staged
```

---

## Task 7: Configure lint-staged in package.json

**Files:** Modify `client/package.json` — add top-level `lint-staged` key.

- [ ] **Step 1: Add lint-staged config**

```json
"lint-staged": {
  "*.{ts,tsx}": [
    "eslint --fix",
    "prettier --write"
  ],
  "*.{json,css,md}": [
    "prettier --write"
  ]
}
```

- [ ] **Step 2: Verify the hook fires on commit**

```bash
git add client/.prettierrc client/.prettierignore client/eslint.config.js client/package.json client/package-lock.json .husky/pre-commit
git commit -m "tooling: add Prettier, Husky, and lint-staged to client"
```

Expected: the pre-commit hook runs lint-staged on staged files, then the commit succeeds.

---

## Verification

```bash
cd client
npm run lint           # ESLint — must exit 0
npm run format:check   # Prettier — lists any unformatted files
```

Make a test commit touching any `.ts` file to confirm Husky fires lint-staged before the commit is recorded.
