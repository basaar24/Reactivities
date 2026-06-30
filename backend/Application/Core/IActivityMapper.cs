using Application.Activities.DTOs;
using Domain;

namespace Application.Core;

public interface IActivityMapper
{
    public Activity CreateActivity(CreateActivityDto request);
    public void ApplyUpdate(UpdateActivityDto source, Activity destination);
    public void CopyTo(Activity source, Activity destination);
}
