using Application.Activities;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivityController : BaseApiController
    {
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(ILogger<ActivityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() =>
            Ok(await _mediator.Send(new List.Query()));

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(int id) =>
            Ok(await _mediator.Send(new Details.Query() { ActivityId = id }));

        [HttpPost]
        public async Task<IActionResult> Create(Activity activity)
        => Created(string.Empty, await _mediator.Send(new Create.Command() { Activity = activity }));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivityById(int id) =>
            Ok(await _mediator.Send(new Delete.Command() { ActivityId = id }));

        [HttpPut]
        public async Task<ActionResult<Activity>> Edit(Activity activity) =>
            Ok(await _mediator.Send(new Edit.Command() { Activity = activity }));
    }
}