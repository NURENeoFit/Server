using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymController : ControllerBase
    {
        private readonly IGymRepository _gymRepository;

        public GymController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gym>>> GetAllGyms()
        {
            var gyms = await _gymRepository.GetAllAsync();
            return Ok(gyms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gym>> GetGymById(int id)
        {
            var gym = await _gymRepository.GetByIdAsync(id);
            if (gym == null)
            {
                return NotFound();
            }
            return Ok(gym);
        }

        [HttpPost]
        public async Task<ActionResult<Gym>> CreateGym([FromBody] Gym gym)
        {
            await _gymRepository.AddAsync(gym);
            await _gymRepository.SaveAsync();
            return CreatedAtAction(nameof(GetGymById), new { id = gym.GymId }, gym);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGym(int id, [FromBody] Gym gym)
        {
            if (id != gym.GymId)
            {
                return BadRequest();
            }

            var existingGym = await _gymRepository.GetByIdAsync(id);
            if (existingGym == null)
            {
                return NotFound();
            }

            _gymRepository.Update(gym);
            await _gymRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            var gym = await _gymRepository.GetByIdAsync(id);
            if (gym == null)
            {
                return NotFound();
            }

            _gymRepository.Delete(gym);
            await _gymRepository.SaveAsync();

            return NoContent();
        }
    }
} 