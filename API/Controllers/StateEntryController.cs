using Application.StateEntries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StateEntryController : BaseApiController
    {
        private readonly ILogger<StateEntryController> _logger;

        public StateEntryController(ILogger<StateEntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateEntry>>> GetStateEntries() =>
            Ok(await _mediator.Send(new List.Query()));

        [HttpGet("{id}")]
        public async Task<ActionResult<StateEntry>> GetStateEntryById(int id) =>
            Ok(await _mediator.Send(new Details.Query() { StateEntryId = id }));

        [HttpPost]
        public async Task<IActionResult> Create(StateEntry StateEntry)
        => Created(string.Empty, await _mediator.Send(new Create.Command() { StateEntry = StateEntry }));

        [HttpDelete("{id}")]
        public async Task<ActionResult<StateEntry>> DeleteStateEntryById(int id) =>
            Ok(await _mediator.Send(new Delete.Command() { StateEntryId = id }));

        [HttpPut]
        public async Task<ActionResult<StateEntry>> Edit(StateEntry StateEntry) =>
            Ok(await _mediator.Send(new Edit.Command() { StateEntry = StateEntry }));
    }
}