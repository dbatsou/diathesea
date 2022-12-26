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
        public async Task<IActionResult> GetStates() =>
            HandleResult(await _mediator.Send(new List.Query()));

        /// <summary>
        /// Returns list of states for the given parent state
        /// </summary>
        /// <param name="parentStateID"></param>
        /// <returns></returns>
        [HttpGet("parent/{parentStateID}")]
        public async Task<IActionResult> GetStatesForParentStateId(int parentStateID) =>
            HandleResult(await _mediator.Send(new DetailsParent.Query() { ParentStateID = parentStateID }));

        /// <summary>
        /// Returns the requested state
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateById(int id) =>
            HandleResult(await _mediator.Send(new Details.Query() { StateId = id }));


    }
}