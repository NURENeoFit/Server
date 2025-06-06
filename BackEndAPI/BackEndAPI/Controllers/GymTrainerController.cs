using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymTrainerController : ControllerBase
    {
        private readonly IGymTrainerRepository _gymTrainerRepository;

        public GymTrainerController(IGymTrainerRepository gymTrainerRepository)
        {
            _gymTrainerRepository = gymTrainerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymTrainer>>> GetAllGymTrainers()
        {
            var trainers = await _gymTrainerRepository.GetAllGymTrainersAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymTrainer>> GetGymTrainerById(int id)
        {
            var trainer = await _gymTrainerRepository.GetGymTrainerByIdAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<ActionResult<GymTrainer>> CreateGymTrainer([FromBody] GymTrainer trainer)
        {
            var createdTrainer = await _gymTrainerRepository.CreateGymTrainerAsync(trainer);
            return CreatedAtAction(nameof(GetGymTrainerById), new { id = createdTrainer.GymTrainerId }, createdTrainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGymTrainer(int id, [FromBody] GymTrainer trainer)
        {
            if (id != trainer.GymTrainerId)
            {
                return BadRequest();
            }

            var updatedTrainer = await _gymTrainerRepository.UpdateGymTrainerAsync(trainer);
            if (updatedTrainer == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymTrainer(int id)
        {
            var result = await _gymTrainerRepository.DeleteGymTrainerAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 