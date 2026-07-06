# Workflow & Collaboration Rules

These apply to the whole repo, regardless of which part (backend/frontend) is being touched.

## Communication
- Explain non-obvious technical decisions in plain English before or alongside the code.
- If a task, requirement, or acceptance criterion is ambiguous, ask a clarifying question instead of guessing.
- Keep responses concise and focused on the change requested — don't pad with restatements of the task.

## Code quality bar
- Prioritize readability and maintainability over cleverness.
- Apply DRY and KISS, but don't abstract prematurely — duplication is cheaper than the wrong abstraction.
- Delete unused code, dead branches, and speculative "just in case" scaffolding rather than commenting it out or leaving it in place.
- Write self-documenting code first (clear names, small functions); add a comment only when the *why* isn't obvious from the code itself (e.g., a workaround for a library bug, a non-obvious business rule).
- Follow the existing project structure and conventions already established in the repo — don't introduce a new pattern for something the codebase already solves a different way without flagging it first.

## Errors and type safety
- Fix compiler/type errors and warnings at the source. Don't suppress, ignore, or work around them (no blanket `#pragma warning disable`, no `@ts-ignore`, no `any`-as-escape-hatch) without a one-line comment justifying why.
- Don't mark a task done if the build has warnings introduced by that change.

## Verification
- After a change, state how it was verified (tests run, build passed, manually traced logic) rather than presenting it as done by assumption.
- Don't claim a fix works if it hasn't been checked against the actual failure — surface uncertainty instead of a confident guess.

## Scope discipline
- Stay inside the scope of the requested change. If you notice an unrelated issue, call it out separately rather than fixing it inline as part of an unrelated task.
- No large refactors bundled silently into a small fix — flag the refactor as optional/separate.
