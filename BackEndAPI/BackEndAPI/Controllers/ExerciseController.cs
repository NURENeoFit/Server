using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;
using BackEndAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllAsync();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExerciseById(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        [HttpGet("workoutprogram/{workoutProgramId}")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercisesByWorkOutProgram(int workoutProgramId)
        {
            var exercises = await _exerciseRepository.GetAllExercisesByWorkOutProgramId(workoutProgramId);
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise([FromBody] Exercise exercise)
        {
            await _exerciseRepository.AddAsync(exercise);
            await _exerciseRepository.SaveAsync();
            return CreatedAtAction(nameof(GetExerciseById), new { id = exercise.ExerciseId }, exercise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody] Exercise updateExercise)
        {
            var existingExercise = await _exerciseRepository.GetByIdAsync(id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            existingExercise.Name = updateExercise.Name;
            existingExercise.Duration = updateExercise.Duration;
            existingExercise.BurnedCalories = updateExercise.BurnedCalories;
            existingExercise.WorkoutProgramId = updateExercise.WorkoutProgramId;

            _exerciseRepository.Update(existingExercise);
            await _exerciseRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _exerciseRepository.Delete(exercise);
            await _exerciseRepository.SaveAsync();

            return NoContent();
        }
    }
}
