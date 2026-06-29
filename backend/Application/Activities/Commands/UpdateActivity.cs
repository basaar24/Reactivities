using Application.Activities.DTOs;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class UpdateActivity
{
    public class Command : IRequest<Result<Unit>>
    {
        public required UpdateActivityDto ActivityDto { get; set; }
    }

    public class Handler(AppDbContext context, IActivityMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            Activity? activity = await context.Activities.FindAsync([request.ActivityDto.Id], cancellationToken);

            if (activity == null)
            {
                return Result<Unit>.Failure("Activity not found", 404);
            }

            mapper.ToDomain(request.ActivityDto, activity);

            bool result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                return Result<Unit>.Failure("Failed to update the activity", 400);
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
