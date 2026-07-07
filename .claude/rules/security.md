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

## Web & API security
- Enforce HTTPS everywhere; don't add HTTP fallback endpoints for convenience.
- Configure CORS with an explicit allowlist of origins — never `AllowAnyOrigin()` combined with credentials, and avoid wildcard CORS in production generally.
- Every endpoint that isn't intentionally public must go through authentication and authorization middleware — don't rely on "the frontend won't call it" as a security boundary.
- Use secure, httpOnly, `SameSite` cookies for session/auth tokens where the project's auth model uses cookies; add CSRF protection for state-changing form submissions.
- Set a Content-Security-Policy header where feasible; avoid inline scripts/styles that would force a permissive CSP.
- Validate file uploads on type, size, and (where relevant) content — don't trust the client-provided MIME type or extension alone.

## Config
- No hardcoded environment-specific values (URLs, connection strings, feature flags) in source — pull from configuration/environment variables so the same build works across dev/staging/prod.

## Git hygiene
- Follow the repo's existing commit message convention; if none exists, use clear, present-tense, single-purpose commit messages.
- Never push directly to `main`/`master` or other protected branches — work through a branch and PR.
- Keep PRs/diffs focused on one concern so they're reviewable; don't bundle unrelated changes.
