---
description: Enforce mandatory steps from openspec/config.yaml when creating tasks.md artifacts and ensure agent executes all manual tests
alwaysApply: true
---

# OpenSpec Tasks: Mandatory Steps Enforcement

When creating or updating `tasks.md` artifacts in OpenSpec changes, you MUST:

## 1. Read openspec/config.yaml First

**BEFORE** creating or updating any `tasks.md` file, you MUST read `openspec/config.yaml` to understand:
- Backend and frontend-specific mandatory steps
- Branch naming conventions
- Task structure requirements
- Testing and documentation requirements

## 2. Mandatory Steps

All implementation tasks MUST include these steps in the correct order:

### Step 0: Create Feature Branch (MUST BE FIRST)
- **Location**: Must be the very first step (Step 0)
- **Branch naming**: `feature/[change-name]`
- **Action**: Create and switch to feature branch before any code changes

### Mandatory Steps (Must Be Included):
- **Step N**: Review and Update Existing Unit Tests (MANDATORY — note: no test project exists yet; create one or document the gap)
- **Step N+1**: Build Verification and Database State Check (MANDATORY)
- **Step N+2**: Manual Endpoint Testing with curl (MANDATORY) — **AGENT MUST EXECUTE**
- **Step N+3**: E2E Testing with Playwright MCP (MANDATORY if frontend changes are involved) — **AGENT MUST EXECUTE**
- **Step N+4**: Update Technical Documentation (MANDATORY)

## 3. Manual Testing Requirements — CRITICAL: Agent Must Execute

**IMPORTANT**: The coding agent (AI) MUST perform all manual testing steps itself. **NEVER delegate testing to the user**. These tests must be executed by the agent to mark tasks as completed in `tasks.md`.

### Step N+1: Build Verification and Database State Check (MANDATORY)

**Agent Responsibility**: The coding agent MUST verify the build compiles cleanly and validate database integrity. This is NOT optional.

**Implementation Steps** (Agent must perform):
1. **Run backend build**:
   ```bash
   cd backend && dotnet build
   ```
   Expected: exit 0, zero errors.

2. **Run frontend build** (if frontend was changed):
   ```bash
   cd client && npm run build
   ```
   Expected: exit 0, zero TypeScript errors.

3. **Verify database state** (when applicable):
   - Start the API (`dotnet run --project API`) and confirm it starts without migration errors.
   - Query the Activities endpoint to verify the count and shape of records match expectations.
   - Check SQLite file exists at `backend/API/reactivities.db`.

4. **Create Build Verification Report in Spec Folder**:
   - Save report under the current change folder: `specs/<change-name>/reports/`
   - Filename pattern: `YYYY-MM-DD-step-N+1-build-and-db-verification.md`
   - Include: commands executed, exit codes, any warnings, database record count.

5. **Mark Task as Completed**: Only after build exits 0 and the report file is created.

**Report Template**:
```markdown
# Step N+1 Report — Build and Database Verification

- Date: YYYY-MM-DD
- Change: <change-name>
- Agent: <agent-name>

## Commands Executed
- `cd backend && dotnet build`
- `cd client && npm run build` (if applicable)

## Build Results
- Backend: PASS/FAIL (exit code: N)
- Frontend: PASS/FAIL/SKIPPED (exit code: N)
- Warnings: <none or list>

## Database State
- reactivities.db exists: Yes/No
- Activities count (GET /api/activities): N records
- Any migration errors on startup: Yes/No

## Outcome
- Step N+1 status: PASS/FAIL
- Blocking issues: <none or list>
```

### Step N+2: Manual Endpoint Testing with curl (MANDATORY)

**Agent Responsibility**: The coding agent MUST execute all curl commands and verify responses. This is NOT optional.

**Base URL**: `https://localhost:5001/api` (use `-k` to skip self-signed cert verification)

**Implementation Steps** (Agent must perform):
1. **Start the backend server** if not already running:
   ```bash
   cd backend && dotnet run --project API
   ```

2. **Test GET /activities** (list all):
   ```bash
   curl -k https://localhost:5001/api/activities
   ```
   Verify: status 200, JSON array of Activity objects.

3. **Test GET /activities/{id}** (single record):
   - Take a GUID from the list response.
   ```bash
   curl -k https://localhost:5001/api/activities/<id>
   ```
   Verify: status 200, single Activity object with all 10 fields.

4. **Test POST /activities** (create):
   ```bash
   curl -k -X POST https://localhost:5001/api/activities \
     -H "Content-Type: application/json" \
     -d '{"title":"Test Activity","date":"2026-12-01T10:00:00","description":"Test description","category":"drinks","city":"London","venue":"Test Venue","latitude":51.5,"longitude":-0.1}'
   ```
   Verify: status 200, response body is a plain GUID string.
   **Restore**: DELETE the created record after testing (see DELETE step).

5. **Test PUT /activities** (update):
   - Use an existing activity's ID.
   ```bash
   curl -k -X PUT https://localhost:5001/api/activities \
     -H "Content-Type: application/json" \
     -d '{"id":"<id>","title":"Updated Title","date":"2026-12-01T10:00:00","description":"Updated desc","category":"culture","isCancelled":false,"city":"Paris","venue":"Updated Venue","latitude":48.8,"longitude":2.3}'
   ```
   Verify: status 204, no response body.
   **Restore**: PUT again with original values after verifying.

6. **Test DELETE /activities/{id}** (delete):
   - Use the GUID created in step 4 (or a test GUID created for this purpose).
   ```bash
   curl -k -X DELETE https://localhost:5001/api/activities/<id>
   ```
   Verify: status 200.

7. **Test error cases**:
   - GET with non-existent ID → expect 404.
   - POST with missing required fields → expect 400.

8. **Mark Task as Completed**: Only after all curl tests pass and database is restored.

**Notes**:
- **The agent MUST execute all curl commands itself** — never ask the user to run tests.
- All CREATE/UPDATE/DELETE operations must restore the database to its pre-test state.
- Document all curl commands and responses in a report in `specs/<change-name>/reports/`.

### Step N+3: E2E Testing with Playwright MCP (MANDATORY if frontend changes)

**Agent Responsibility**: The coding agent MUST execute all E2E tests using Playwright MCP tools.

**When This Applies**: Any change that affects the frontend UI or user workflows.

**Base URL**: `https://localhost:3000`

**Implementation Steps** (Agent must perform):
1. **Ensure both servers are running**:
   - Backend: `dotnet run --project API` (port 5001)
   - Frontend: `cd client && npm run dev` (port 3000)

2. **Navigate to application**:
   - Use `browser_navigate` to open `https://localhost:3000`.
   - Take a snapshot to verify initial state.

3. **Execute user workflows** relevant to the change using Playwright MCP tools:
   - `browser_click` — button clicks, navigation
   - `browser_type` / `browser_fill` — form inputs
   - `browser_snapshot` — verify state
   - `browser_wait` — async operations (prefer incremental 1–3 second waits)

4. **Test error scenarios**: form validation, missing fields, error messages.

5. **Verify data persistence**: after create/update via UI, confirm via GET API that the record matches.

6. **Restore test environment**: clean up any test data created during E2E tests.

7. **Mark Task as Completed**: Only after all E2E tests pass and environment is restored.

**Notes**:
- **The agent MUST execute all E2E tests itself** — never ask the user.
- Document test scenarios and outcomes in a report in `specs/<change-name>/reports/`.

---

## 4. Verification Checklist

Before finalizing any `tasks.md` file, verify:
- [ ] Step 0 (Create Feature Branch) is the FIRST step
- [ ] Branch naming follows `feature/<change-name>`
- [ ] Steps are numbered sequentially
- [ ] Mandatory steps are clearly marked with "(MANDATORY)"
- [ ] Step N+1 includes report path and naming convention
- [ ] Manual testing steps explicitly state "AGENT MUST EXECUTE"
- [ ] Tasks include database state restoration steps for POST/PUT/DELETE
- [ ] E2E testing step is included if frontend changes are involved
- [ ] Step N+4 lists which docs to update (`api-spec.yml`, `data-model.md`, `backend-standards.md`, `frontend-standards.md`)

---

## 5. When This Applies

This rule applies when:
- Creating `tasks.md` via `/opsx:ff` (fast-forward) or `openspec-ff-change` skill
- Creating `tasks.md` via `/opsx:continue` (continue change) or `openspec-continue-change` skill
- Updating existing `tasks.md` files
- Implementing tasks from `tasks.md` via `/opsx:apply` or `openspec-apply-change` skill — the agent must execute manual tests

---

## 6. Example Structure

```markdown
## 0. Setup: Create Feature Branch (MANDATORY — FIRST STEP)

- [ ] 0.1 Create feature branch `feature/<change-name>` from main branch
- [ ] 0.2 Verify branch creation and current branch status

## 1. Backend: [Implementation Task]
...

## N. Backend: Review and Update Existing Unit Tests (MANDATORY)
...

## N+1. Backend: Build Verification and Database State Check (MANDATORY)
- [ ] N+1.1 Run `cd backend && dotnet build` — must exit 0
- [ ] N+1.2 Run `cd client && npm run build` (if frontend changed) — must exit 0
- [ ] N+1.3 Start API and verify database seeds/migrates without error
- [ ] N+1.4 Query GET /api/activities and verify expected record count
- [ ] N+1.5 Create report `specs/<change-name>/reports/YYYY-MM-DD-step-N+1-build-and-db-verification.md`
- [ ] N+1.6 Mark step complete only after build passes and report exists

## N+2. Backend: Manual Endpoint Testing with curl (MANDATORY — AGENT MUST EXECUTE)
- [ ] N+2.1 Ensure backend is running on https://localhost:5001
- [ ] N+2.2 Test GET /api/activities — verify 200 and array response
- [ ] N+2.3 Test GET /api/activities/{id} — verify 200 and single Activity
- [ ] N+2.4 Test POST /api/activities — verify 200 and GUID returned; then restore (DELETE)
- [ ] N+2.5 Test PUT /api/activities — verify 204; then restore original values
- [ ] N+2.6 Test DELETE /api/activities/{id} — verify 200
- [ ] N+2.7 Test error cases (404 for unknown id, 400 for missing required fields)
- [ ] N+2.8 Document all curl commands and responses in spec folder report

## N+3. Frontend: E2E Testing with Playwright MCP (MANDATORY if applicable — AGENT MUST EXECUTE)
- [ ] N+3.1 Ensure frontend (port 3000) and backend (port 5001) are running
- [ ] N+3.2 Navigate to https://localhost:3000 using Playwright MCP browser_navigate
- [ ] N+3.3 Execute complete user workflow using Playwright MCP tools
- [ ] N+3.4 Test error scenarios and validation
- [ ] N+3.5 Verify data persistence (UI action → API GET confirms)
- [ ] N+3.6 Restore test environment and database state
- [ ] N+3.7 Document test scenarios and outcomes in spec folder report

## N+4. Update Technical Documentation (MANDATORY)
- [ ] N+4.1 Update `docs/api-spec.yml` if endpoints changed
- [ ] N+4.2 Update `docs/data-model.md` if Activity entity changed
- [ ] N+4.3 Update `docs/backend-standards.md` if architecture patterns changed
- [ ] N+4.4 Update `docs/frontend-standards.md` if frontend patterns changed
- [ ] N+4.5 Update `docs/development_guide.md` if setup steps changed
```

---

## 7. Agent Execution Requirements

**CRITICAL**: When implementing tasks from `tasks.md`, the coding agent MUST:

1. **Execute All Manual Tests**: Never ask the user to run curl commands or E2E tests. The agent must:
   - Start servers if needed
   - Execute all curl commands
   - Execute all E2E tests using Playwright MCP tools
   - Verify all responses and outcomes
   - Restore database state after tests

2. **Mark Tasks as Completed**: Tasks can ONLY be marked (`[x]`) AFTER:
   - The agent has successfully executed all required tests
   - All test results have been verified
   - Database state has been restored (for POST/PUT/DELETE operations)
   - All test outcomes have been documented

3. **Never Delegate Testing**: The agent must never:
   - Ask the user to run curl commands or test endpoints manually
   - Ask the user to run E2E tests
   - Mark tasks as completed without executing tests
   - Skip manual testing steps even when code changes look small

4. **Document Test Execution**: The agent must document:
   - All curl commands executed with their full responses
   - All E2E test scenarios executed
   - Database state restoration actions
   - Any issues encountered and resolutions

---

## Failure to Follow

If you create tasks without following these mandatory steps, the user will need to manually fix the `tasks.md` file. Always read `openspec/config.yaml` first and ensure all mandatory steps are included.

**If you implement tasks without executing manual tests yourself, you are violating this rule. The agent must execute all tests to mark tasks as completed.**
