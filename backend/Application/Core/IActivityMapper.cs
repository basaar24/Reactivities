using Application.Activities.Requests;
using Domain;

namespace Application.Core;

public interface IActivityMapper
{
    Activity ToActivity(CreateActivityRequest request);
    void UpdateActivity(Activity source, Activity destination);
}
