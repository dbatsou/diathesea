using Application.ActivityEntries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivityEntryController : BaseApiController
    {
        private readonly ILogger<ActivityEntryController> _logger;

        public ActivityEntryController(ILogger<ActivityEntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityEntry>>> GetActivityEntries() =>
            Ok(await _mediator.Send(new List.Query()));

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityEntry>> GetActivityEntryById(int id) =>
            Ok(await _mediator.Send(new Details.Query() { ActivityEntryId = id }));

        [HttpPost]
        public async Task<IActionResult> Create(ActivityEntry ActivityEntry)
        => Created(string.Empty, await _mediator.Send(new Create.Command() { ActivityEntry = ActivityEntry }));

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityEntry>> DeleteActivityEntryById(int id) =>
            Ok(await _mediator.Send(new Delete.Command() { ActivityEntryId = id }));

        [HttpPut]
        public async Task<ActionResult<ActivityEntry>> Edit(ActivityEntry ActivityEntry) =>
            Ok(await _mediator.Send(new Edit.Command() { ActivityEntry = ActivityEntry }));
    }
}