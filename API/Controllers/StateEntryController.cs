using Application.StateEntries;
using Domain.Entities;
using MediatR;
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
        public async Task<IActionResult> GetStateEntries() =>
            HandleResult<List<StateEntry>>(await _mediator.Send(new List.Query()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateEntryById(int id) =>
            HandleResult<StateEntry>(await _mediator.Send(new Details.Query() { StateEntryId = id }));

        [HttpPost]
        public async Task<IActionResult> Create(StateEntry StateEntry)
        => Created(string.Empty, await _mediator.Send(new Create.Command() { StateEntry = StateEntry }));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateEntryById(int id) =>
            HandleResult<Unit>(await _mediator.Send(new Delete.Command() { StateEntryId = id }));

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, StateEntry StateEntry) =>
             HandleResult<StateEntry>(await _mediator.Send(new Edit.Command() { Id = id, StateEntry = StateEntry }));
    }
}