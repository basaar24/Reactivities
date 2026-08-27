using Application.Activities.Queries;
using Application.Activities.Commands;
using Application.Activities.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Activity>>> GetActivitiesAsync() => await Mediator.Send(new GetActivityList.Query());

    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id) => HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivityAsync(CreateActivityDto activityDto) => HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));

    [HttpPut]
    public async Task<ActionResult> UpdateActivityAsync(UpdateActivityDto activity) => HandleResult(await Mediator.Send(new UpdateActivity.Command { ActivityDto = activity }));

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivityAsync(string id) => HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
}
