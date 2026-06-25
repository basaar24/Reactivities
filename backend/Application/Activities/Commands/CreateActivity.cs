using Application.Activities.Requests;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required CreateActivityRequest ActivityRequest { get; set; }
    }

    public class Handler(AppDbContext context, IActivityMapper mapper)
        : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = mapper.ToActivity(request.ActivityRequest);
            context.Activities.Add(activity);
            await context.SaveChangesAsync(cancellationToken);
            return activity.Id;
        }
    }
}
