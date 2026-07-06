# Security Rules

Applies across backend and frontend.

## Secrets & credentials
- Never commit secrets, API keys, connection strings, or tokens to the repo — use environment variables, `dotnet user-secrets` locally, and a proper secrets manager (Key Vault, etc.) in deployed environments.
- Never log secrets, tokens, passwords, or full PII (emails, addresses, payment info) — mask or omit them from log output.
- If you spot a hardcoded secret in existing code, flag it explicitly rather than silently working around it.

## Input & data handling
- Treat all external input (API request bodies, query params, form input, file uploads) as untrusted — validate at the boundary before it reaches business logic.
- Never build SQL, shell commands, or file paths via raw string concatenation with user input.
- Sanitize any user-generated content before rendering it as HTML.

## Config
- No hardcoded environment-specific values (URLs, connection strings, feature flags) in source — pull from configuration/environment variables so the same build works across dev/staging/prod.

## Git hygiene
- Follow the repo's existing commit message convention; if none exists, use clear, present-tense, single-purpose commit messages.
- Never push directly to `main`/`master` or other protected branches — work through a branch and PR.
- Keep PRs/diffs focused on one concern so they're reviewable; don't bundle unrelated changes.
