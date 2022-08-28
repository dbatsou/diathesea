using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage;

namespace API.Controllers
{
    public class StateController : BaseApiController
    {
        private readonly ILogger<StateController> _logger;
        private DataContext _context;

        public StateController(ILogger<StateController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<State>>> GetStates()
        {
            var states = await _context.State
            .Where(st => st.ParentStateID == null)
            .ToListAsync();

            return Ok(states);
        } 

        [HttpGet("parent/{id}")]
        public async Task<ActionResult<List<State>>> GetStatesForParentStateId(int id)
        {
            var state = await _context.State.Where(st => st.ParentStateID == id).ToListAsync();

            return Ok(state);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetStateById(int id)
        {
            var state = await _context.State.Where(st => st.StateId == id).FirstOrDefaultAsync();

            return Ok(state);
        }


    }
}