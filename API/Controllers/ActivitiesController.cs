using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivitiesAsync()
    {
        return await Mediator.Send(new GetActivitiesList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetailAsync(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query{ Id = id });
    }
}
