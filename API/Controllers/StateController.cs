using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.States;

namespace API.Controllers
{
    public class StateController : BaseApiController
    {
        private readonly ILogger<StateController> _logger;

        public StateController(ILogger<StateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<State>>> GetStates() =>
            Ok(await _mediator.Send(new List.Query()));


        [HttpGet("parent/{parentStateID}")]
        public async Task<ActionResult<List<State>>> GetStatesForParentStateId(int parentStateID) =>
            Ok(await _mediator.Send(new DetailsParent.Query() { ParentStateID = parentStateID }));

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetStateById(int id) =>
            Ok(await _mediator.Send(new Details.Query() { StateId = id }));

        [HttpPost]
        public async Task<IActionResult> Create(State state)
        => Created(string.Empty, await _mediator.Send(new Create.Command() { State = state }));

        [HttpDelete("{id}")]
        public async Task<ActionResult<State>> DeleteStateById(int id) =>
            Ok(await _mediator.Send(new Delete.Command() { Id = id }));

        [HttpPut]
        public async Task<ActionResult<State>> Edit(State state) =>
            Ok(await _mediator.Send(new Edit.Command() { State = state }));
    }
}