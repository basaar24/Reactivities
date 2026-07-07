---
paths: ["**/*.cs", "**/*.csproj", "**/*.sln"]
---

# .NET / C# Rules

## Architecture & structure
- Follow Clean Architecture / layered separation already used in this repo (Domain, Application, Persistence, API) — don't leak infrastructure concerns (EF Core types, HTTP context) into domain or application layers.
- Prefer CQRS-style separation of reads and writes when the project already uses MediatR-style handlers; don't introduce a second pattern for the same concern.
- Keep controllers/endpoints thin — orchestration logic belongs in application services or handlers, not in the controller action.
- Apply SOLID pragmatically: favor composition over inheritance, depend on abstractions (interfaces) at boundaries, but don't create an interface for a class with a single implementation and no test need.

## Async & performance
- Use `async`/`await` all the way down for I/O-bound work; never block on async code with `.Result` or `.Wait()`.
- Pass and honor `CancellationToken` on public async methods that do I/O.
- Use `IAsyncEnumerable<T>` for streaming large result sets instead of materializing full lists when it matters for the call site.
- Avoid `async void` except for event handlers.
- Cache data that's expensive to fetch and doesn't change often (`IMemoryCache` for single-instance, a distributed cache like Redis for multi-instance deployments) — but only after confirming it's actually a bottleneck, not by default.
- Paginate any endpoint that can return an unbounded collection; never return an entire table's worth of rows in one response.

## Nullability & types
- Nullable reference types must stay enabled; don't suppress with `!` unless the non-null invariant is genuinely guaranteed and documented with a comment.
- Use records for immutable DTOs/value objects; use classes for entities with identity and behavior.
- Avoid primitive obsession for domain concepts that recur (e.g., wrap an `OrderId`/`Email` rather than passing raw `string`/`Guid`) when the codebase already leans that way — don't introduce it as a one-off.

## Error handling
- Don't use exceptions for expected control flow (e.g., validation failures) — prefer a Result/OneOf-style pattern or clear validation responses if that's the existing convention; otherwise use targeted exception types with meaningful messages.
- Never swallow exceptions silently (`catch { }`); log with context or rethrow.
- Validate inputs at the boundary (API/application layer), not deep inside domain logic.

## Testing
- Cover new business logic with unit tests; use integration tests for anything touching EF Core, external APIs, or the database.
- Mock external dependencies at the interface boundary — don't spin up real external services in unit tests.
- A change to a public method's behavior should come with an updated or new test, not just a manual "it works" claim.

## Data access (EF Core)
- Use `AsNoTracking()` for read-only queries; only track entities you intend to modify.
- Avoid N+1 queries — use `Include`/`ThenInclude` or project directly into a DTO with `Select` instead of lazy-loading in a loop.
- Never expose EF Core entities directly from API endpoints — map to request/response DTOs, even when the shapes look identical today.
- Review generated migrations before applying them; don't auto-apply migrations against production without a review step.

## Cross-cutting concerns
- Handle exceptions centrally (global exception-handling middleware / `IExceptionHandler`) rather than scattering try/catch blocks across controllers for the same generic error response.
- Use structured logging (e.g., `ILogger` with named parameters: `_logger.LogInformation("Order {OrderId} created", orderId)`), not string concatenation or interpolation into the log message itself.
- Wrap outbound calls to external services (HTTP APIs, third-party SDKs) with a resilience policy (retry, timeout, circuit breaker — e.g., Polly) instead of a bare call with no failure handling.

## Dependency injection
- Register services with the narrowest lifetime that's correct (Scoped for most app services, Singleton only for genuinely stateless/thread-safe services, Transient sparingly).
- Avoid service locator patterns (`IServiceProvider.GetService` sprinkled through business code) — inject dependencies explicitly through constructors.

## Naming & style
- PascalCase for class names, method names, and public members; camelCase for locals and parameters; `_camelCase` for private fields if that's the existing convention in this repo.
- UPPERCASE (or PascalCase, matching repo convention) for constants.
- Prefix interfaces with `I` (`IUserService`).
- Use `var` when the right-hand side already makes the type obvious (`var user = new User()`); use an explicit type when it aids readability (`int count = items.Count()` is fine either way, but avoid `var` when the return type is opaque, like from a poorly-named method).
- Keep methods small and single-purpose; if a method needs a "part 1 / part 2" comment to explain itself, it's a signal to extract a method.

## API design
- Follow RESTful conventions for resource naming and HTTP verbs; use attribute routing on controllers.
- Version the API from the start (URL segment, header, or query string — match whatever the project already uses) rather than bolting on versioning after the first breaking change.
- Use action filters for cross-cutting concerns that apply to multiple endpoints (e.g., logging, validation shortcuts) instead of repeating the same logic in each action.
- Return consistent, typed error responses (e.g., `ProblemDetails`) and correct HTTP status codes — don't return 200 with an error payload embedded in the body.

## API documentation
- Keep Swagger/OpenAPI (Swashbuckle or equivalent) working for every new/changed endpoint — don't ship an endpoint that breaks or omits itself from the generated docs.
- Add XML doc comments on public controller actions and DTOs when the project has XML docs enabled for Swagger — skip this if the project doesn't use it.

## Background work
- Use `IHostedService`/`BackgroundService` for long-running or scheduled background work rather than `Task.Run` fire-and-forget calls inside a request.
- Background jobs must handle and log their own exceptions — an unhandled exception in a hosted service can crash the whole process.
