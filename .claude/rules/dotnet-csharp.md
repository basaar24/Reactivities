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

## Dependency injection
- Register services with the narrowest lifetime that's correct (Scoped for most app services, Singleton only for genuinely stateless/thread-safe services, Transient sparingly).
- Avoid service locator patterns (`IServiceProvider.GetService` sprinkled through business code) — inject dependencies explicitly through constructors.

## Naming & style
- Follow standard .NET naming conventions (PascalCase for public members/types, camelCase for locals/parameters, `_camelCase` for private fields if that's the existing convention in this repo).
- Keep methods small and single-purpose; if a method needs a "part 1 / part 2" comment to explain itself, it's a signal to extract a method.
