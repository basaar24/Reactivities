using Application.Activities.Requests;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required ActivityRequest ActivityRequest { get; set; }
    }

    public class Handler(AppDbContext context, IMapper<ActivityRequest, Activity> mapper)
        : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = mapper.Map(request.ActivityRequest);
            context.Activities.Add(activity);
            await context.SaveChangesAsync(cancellationToken);
            return activity.Id;
        }
    }
}
