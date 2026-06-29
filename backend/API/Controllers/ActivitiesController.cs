using Application.Activities.Queries;
using Application.Activities.Commands;
using Application.Activities.Requests;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivitiesAsync() => await Mediator.Send(new GetActivityList.Query());

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id) => HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivityAsync(CreateActivityRequest activityRequest) => HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityRequest = activityRequest }));

    [HttpPut]
    public async Task<ActionResult> UpdateActivityAsync(Activity activity) => HandleResult(await Mediator.Send(new UpdateActivity.Command { Activity = activity }));

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivityAsync(string id) => HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
}
