using Application.Activities.DTOs;
using Domain;

namespace Application.Core;

public interface IActivityMapper
{
    public Activity ToDomain(CreateActivityDto request);
    public void ToDomain(UpdateActivityDto source, Activity destination);
    public void UpdateActivity(Activity source, Activity destination);
}
