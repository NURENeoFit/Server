using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalRepository _goalRepository;

        public GoalController(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetAllGoals()
        {
            var goals = await _goalRepository.GetAllAsync();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetGoalById(int id)
        {
            var goal = await _goalRepository.GetByIdAsync(id);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpGet("type/{goalType}")]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoalsByType(GoalType goalType)
        {
            var goals = await _goalRepository.GetAllGoalsByTypeAsync(goalType);
            return Ok(goals);
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> CreateGoal([FromBody] Goal goal)
        {
            await _goalRepository.AddAsync(goal);
            await _goalRepository.SaveAsync();
            return CreatedAtAction(nameof(GetGoalById), new { id = goal.GoalId }, goal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] Goal goal)
        {
            if (id != goal.GoalId)
            {
                return BadRequest();
            }

            var existingGoal = await _goalRepository.GetByIdAsync(id);
            if (existingGoal == null)
            {
                return NotFound();
            }

            _goalRepository.Update(goal);
            await _goalRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var goal = await _goalRepository.GetByIdAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            _goalRepository.Delete(goal);
            await _goalRepository.SaveAsync();

            return NoContent();
        }
    }
} 