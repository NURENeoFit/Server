using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupTrainingController : ControllerBase
    {
        private readonly IGroupTrainingRepository _groupTrainingRepository;

        public GroupTrainingController(IGroupTrainingRepository groupTrainingRepository)
        {
            _groupTrainingRepository = groupTrainingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupTraining>>> GetAllGroupTrainings()
        {
            var trainings = await _groupTrainingRepository.GetAllAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTraining>> GetGroupTrainingById(int id)
        {
            var training = await _groupTrainingRepository.GetByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return Ok(training);
        }

        [HttpGet("fitness-center/{fitnessCenterId}")]
        public async Task<ActionResult<IEnumerable<GroupTraining>>> GetGroupTrainingsByFitnessCenterId(int fitnessCenterId)
        {
            var trainings = await _groupTrainingRepository.GetAllGroupTrainingsByFitnessCenterIdAsync(fitnessCenterId);
            return Ok(trainings);
        }

        [HttpGet("specialization/{specializationId}")]
        public async Task<ActionResult<IEnumerable<GroupTraining>>> GetGroupTrainingsBySpecializationId(int specializationId)
        {
            var trainings = await _groupTrainingRepository.GetAllGroupTrainingsBySpecializationIdAsync(specializationId);
            return Ok(trainings);
        }

        [HttpGet("fitness-center/{fitnessCenterId}/specialization/{specializationId}")]
        public async Task<ActionResult<IEnumerable<GroupTraining>>> GetGroupTrainingsByFitnessCenterAndSpecialization(int fitnessCenterId, int specializationId)
        {
            var trainings = await _groupTrainingRepository.GetAllGroupTrainingsByFitnessCenterAndSpecializationAsync(fitnessCenterId, specializationId);
            return Ok(trainings);
        }

        [HttpPost]
        public async Task<ActionResult<GroupTraining>> CreateGroupTraining([FromBody] GroupTraining training)
        {
            await _groupTrainingRepository.AddAsync(training);
            await _groupTrainingRepository.SaveAsync();
            return CreatedAtAction(nameof(GetGroupTrainingById), new { id = training.GroupTrainingId }, training);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupTraining(int id, [FromBody] GroupTraining training)
        {
            if (id != training.GroupTrainingId)
            {
                return BadRequest();
            }

            var existingTraining = await _groupTrainingRepository.GetByIdAsync(id);
            if (existingTraining == null)
            {
                return NotFound();
            }

            _groupTrainingRepository.Update(training);
            await _groupTrainingRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupTraining(int id)
        {
            var training = await _groupTrainingRepository.GetByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            _groupTrainingRepository.Delete(training);
            await _groupTrainingRepository.SaveAsync();

            return NoContent();
        }
    }
} 