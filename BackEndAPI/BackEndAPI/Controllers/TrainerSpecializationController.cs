using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainerSpecializationController : ControllerBase
    {
        private readonly ITrainerSpecializationRepository _trainerSpecializationRepository;

        public TrainerSpecializationController(ITrainerSpecializationRepository trainerSpecializationRepository)
        {
            _trainerSpecializationRepository = trainerSpecializationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerSpecialization>>> GetAllTrainerSpecializations()
        {
            var specializations = await _trainerSpecializationRepository.GetAllAsync();
            return Ok(specializations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerSpecialization>> GetTrainerSpecializationById(int id)
        {
            var specialization = await _trainerSpecializationRepository.GetByIdAsync(id);
            if (specialization == null)
            {
                return NotFound();
            }
            return Ok(specialization);
        }

        //[HttpPost]
        //public async Task<ActionResult<TrainerSpecialization>> CreateTrainerSpecialization([FromBody] TrainerSpecialization specialization)
        //{
        //    await _trainerSpecializationRepository.AddAsync(specialization);
        //    await _trainerSpecializationRepository.SaveAsync();
        //    return CreatedAtAction(nameof(GetTrainerSpecializationById), new { id = specialization.TrainerSpecializationId }, specialization);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTrainerSpecialization(int id, [FromBody] TrainerSpecialization specialization)
        //{
        //    if (id != specialization.TrainerSpecializationId)
        //    {
        //        return BadRequest();
        //    }

        //    var existingSpecialization = await _trainerSpecializationRepository.GetByIdAsync(id);
        //    if (existingSpecialization == null)
        //    {
        //        return NotFound();
        //    }

        //    _trainerSpecializationRepository.Update(specialization);
        //    await _trainerSpecializationRepository.SaveAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTrainerSpecialization(int id)
        //{
        //    var specialization = await _trainerSpecializationRepository.GetByIdAsync(id);
        //    if (specialization == null)
        //    {
        //        return NotFound();
        //    }

        //    _trainerSpecializationRepository.Delete(specialization);
        //    await _trainerSpecializationRepository.SaveAsync();

        //    return NoContent();
        //}
    }
} 