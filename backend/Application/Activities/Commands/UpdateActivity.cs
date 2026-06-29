using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class UpdateActivity
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context, IActivityMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            Activity? activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);

            if (activity == null)
            {
                return Result<Unit>.Failure("Activity not found", 404);
            }

            mapper.UpdateActivity(request.Activity, activity);

            bool result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                return Result<Unit>.Failure("Failed to delete the activity", 400);
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
