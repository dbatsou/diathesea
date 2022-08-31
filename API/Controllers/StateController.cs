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

        /// <summary>
        /// Returns top level states
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<State>>> GetStates() =>
            Ok(await _mediator.Send(new List.Query()));

        /// <summary>
        /// Returns list of states for the given parent state
        /// </summary>
        /// <param name="parentStateID"></param>
        /// <returns></returns>
        [HttpGet("parent/{parentStateID}")]
        public async Task<ActionResult<List<State>>> GetStatesForParentStateId(int parentStateID) =>
            Ok(await _mediator.Send(new DetailsParent.Query() { ParentStateID = parentStateID }));

        /// <summary>
        /// Returns the requested state
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetStateById(int id) =>
            Ok(await _mediator.Send(new Details.Query() { StateId = id }));

        /// <summary>
        /// Creates a new state
        /// </summary>
        /// <param name="state">State object to be created</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(State state)
        => Created(string.Empty, await _mediator.Send(new Create.Command() { State = state }));

        /// <summary>
        /// Deletes state based on state id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<State>> DeleteStateById(int id) =>
            Ok(await _mediator.Send(new Delete.Command() { Id = id }));

        /// <summary>
        /// Updates / Replaces a state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<State>> Edit(State state) =>
            Ok(await _mediator.Send(new Edit.Command() { State = state }));
    }
}