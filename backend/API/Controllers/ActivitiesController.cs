using Application.Activities.Queries;
using Application.Activities.Commands;
using Application.Activities.Requests;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivitiesAsync()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(CreateActivityRequest activityRequest)
    {
        return await Mediator.Send(new CreateActivity.Command { ActivityRequest = activityRequest });
    }

    [HttpPut]
    public async Task<ActionResult> UpdateActivity(Activity activity)
    {
        await Mediator.Send(new UpdateActivity.Command { Activity = activity });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command { Id = id });
        return Ok();
    }
}
