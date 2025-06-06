using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FitnessTrainerController : ControllerBase
    {
        private readonly IFitnessTrainerRepository _fitnessTrainerRepository;

        public FitnessTrainerController(IFitnessTrainerRepository fitnessTrainerRepository)
        {
            _fitnessTrainerRepository = fitnessTrainerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessTrainer>>> GetAllFitnessTrainers()
        {
            var trainers = await _fitnessTrainerRepository.GetAllFitnessTrainersAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessTrainer>> GetFitnessTrainerById(int id)
        {
            var trainer = await _fitnessTrainerRepository.GetFitnessTrainerByIdAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        [HttpGet("specialization/{specializationId}")]
        public async Task<ActionResult<IEnumerable<FitnessTrainer>>> GetFitnessTrainersBySpecialization(int specializationId)
        {
            var trainers = await _fitnessTrainerRepository.GetFitnessTrainersBySpecializationAsync(specializationId);
            return Ok(trainers);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessTrainer>> CreateFitnessTrainer([FromBody] FitnessTrainer trainer)
        {
            var createdTrainer = await _fitnessTrainerRepository.CreateFitnessTrainerAsync(trainer);
            return CreatedAtAction(nameof(GetFitnessTrainerById), new { id = createdTrainer.FitnessTrainerId }, createdTrainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFitnessTrainer(int id, [FromBody] FitnessTrainer trainer)
        {
            if (id != trainer.FitnessTrainerId)
            {
                return BadRequest();
            }

            var updatedTrainer = await _fitnessTrainerRepository.UpdateFitnessTrainerAsync(trainer);
            if (updatedTrainer == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessTrainer(int id)
        {
            var result = await _fitnessTrainerRepository.DeleteFitnessTrainerAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 