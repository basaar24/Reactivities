using Application.Activities.Requests;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<Result<string>>
    {
        public required CreateActivityRequest ActivityRequest { get; set; }
    }

    public class Handler(AppDbContext context, IActivityMapper mapper) : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = mapper.ToActivity(request.ActivityRequest);
            context.Activities.Add(activity);
            bool result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result)
            {
                return Result<string>.Failure("Failed to delete the activity", 400);
            }

            return Result<string>.Success(activity.Id);
        }
    }
}
