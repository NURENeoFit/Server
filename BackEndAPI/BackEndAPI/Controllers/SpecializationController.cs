using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationRepository _specializationRepository;

        public SpecializationController(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialization>>> GetAllSpecializations()
        {
            var specializations = await _specializationRepository.GetAllAsync();
            return Ok(specializations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Specialization>> GetSpecializationById(int id)
        {
            var specialization = await _specializationRepository.GetByIdAsync(id);
            if (specialization == null)
            {
                return NotFound();
            }
            return Ok(specialization);
        }

        [HttpGet("trainer/{trainerId}")]
        public async Task<ActionResult<IEnumerable<Specialization>>> GetSpecializationsByTrainerId(int trainerId)
        {
            var specializations = await _specializationRepository.GetSpecializationsByTrainerIdAsync(trainerId);
            return Ok(specializations);
        }

        [HttpPost]
        public async Task<ActionResult<Specialization>> CreateSpecialization([FromBody] Specialization specialization)
        {
            await _specializationRepository.AddAsync(specialization);
            await _specializationRepository.SaveAsync();
            return CreatedAtAction(nameof(GetSpecializationById), new { id = specialization.SpecializationId }, specialization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialization(int id, [FromBody] Specialization specialization)
        {
            if (id != specialization.SpecializationId)
            {
                return BadRequest();
            }

            var existingSpecialization = await _specializationRepository.GetByIdAsync(id);
            if (existingSpecialization == null)
            {
                return NotFound();
            }

            _specializationRepository.Update(specialization);
            await _specializationRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            var specialization = await _specializationRepository.GetByIdAsync(id);
            if (specialization == null)
            {
                return NotFound();
            }

            _specializationRepository.Delete(specialization);
            await _specializationRepository.SaveAsync();

            return NoContent();
        }
    }
} 