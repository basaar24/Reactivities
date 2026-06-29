using Application.Activities.Requests;
using Domain;

namespace Application.Core;

public interface IActivityMapper
{
    public Activity ToActivity(CreateActivityRequest request);
    public void UpdateActivity(Activity source, Activity destination);
}
