using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.States;
using MediatR;

namespace API.Controllers
{
    public class StateController : BaseApiController
    {
        private readonly ILogger<StateController> _logger;
        private readonly IMediator _mediator;

        public StateController(ILogger<StateController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<State>>> GetStates()
        {
            var states = await _mediator.Send(new List.Query());

            return Ok(states);
        }

        [HttpGet("parent/{id}")]
        public async Task<ActionResult<List<State>>> GetStatesForParentStateId(int id)
        {
            // var state = await _context.State.Where(st => st.ParentStateID == id).ToListAsync();

            // return Ok(state);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetStateById(int id)
        {
            // var state = await _context.State.Where(st => st.StateId == id).FirstOrDefaultAsync();

            // return Ok(state);
            return Ok();
        }


    }
}