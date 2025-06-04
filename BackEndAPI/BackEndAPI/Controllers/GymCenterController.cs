using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymCenterController : ControllerBase
    {
        private readonly IGymCenterRepository _gymCenterRepository;
        private readonly IGenericRepository<Gym> _gymRepository;
        private readonly IGenericRepository<GymMembership> _gymMembershipRepository;

        public GymCenterController(
            IGymCenterRepository gymCenterRepository,
            IGenericRepository<Gym> gymRepository,
            IGenericRepository<GymMembership> membershipRepository)
        {
            _gymCenterRepository = gymCenterRepository;
            _gymRepository = gymRepository;
            _gymMembershipRepository = membershipRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymCenter>> GetGymCenterById(int id)
        {
            var gymCenter = await _gymCenterRepository.GetByIdAsync(id);
            if (gymCenter == null)
                return NotFound();

            return Ok(gymCenter);
        }

        [HttpPost]
        public async Task<ActionResult<GymCenter>> CreateGymCenter([FromBody] GymCenter gymCenter)
        {
            await _gymCenterRepository.AddAsync(gymCenter);
            await _gymCenterRepository.SaveAsync();

            return CreatedAtAction(nameof(GetGymCenterById), new { id = gymCenter.GymCenterId }, gymCenter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGymCenter(int id, [FromBody] GymCenter updated)
        {
            var existing = await _gymCenterRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.GymCenterName = updated.GymCenterName;
            existing.GymMembership = updated.GymMembership;
            existing.SportComplexId = updated.SportComplexId;

            _gymCenterRepository.Update(existing);
            await _gymCenterRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymCenter(int id)
        {
            var gymCenter = await _gymCenterRepository.GetByIdAsync(id);
            if (gymCenter == null)
                return NotFound();

            var hasGyms = await _gymRepository.GetAllAsync();
            var gymsLinked = hasGyms.Any(g => g.GymCenterId == id);

            var hasMemberships = await _gymMembershipRepository.GetAllAsync();
            var membershipsLinked = hasMemberships.Any(m => m.GymCenterId == id);

            if (gymsLinked || membershipsLinked)
            {
                return BadRequest("Cannot delete a gym center that has gyms or memberships. ");
            }

            _gymCenterRepository.Delete(gymCenter);
            await _gymCenterRepository.SaveAsync();

            return NoContent();
        }

        [HttpGet("complex/{sportComplexId}/gyms")]
        public async Task<ActionResult<IEnumerable<Gym>>> GetGymsBySportComplex(int sportComplexId)
        {
            var gyms = await _gymCenterRepository.GetAllGymsByComplexIdAsync(sportComplexId);
            return Ok(gyms);
        }
    }
}

