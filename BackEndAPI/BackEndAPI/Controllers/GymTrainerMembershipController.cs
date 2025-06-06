using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymTrainerMembershipController : ControllerBase
    {
        private readonly IGymTrainerMembershipRepository _gymTrainerMembershipRepository;

        public GymTrainerMembershipController(IGymTrainerMembershipRepository gymTrainerMembershipRepository)
        {
            _gymTrainerMembershipRepository = gymTrainerMembershipRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymTrainerMembership>>> GetAllGymTrainerMemberships()
        {
            var memberships = await _gymTrainerMembershipRepository.GetAllGymTrainerMembershipsAsync();
            return Ok(memberships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymTrainerMembership>> GetGymTrainerMembershipById(int id)
        {
            var membership = await _gymTrainerMembershipRepository.GetGymTrainerMembershipByIdAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return Ok(membership);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GymTrainerMembership>>> GetGymTrainerMembershipsByUserId(int userId)
        {
            var memberships = await _gymTrainerMembershipRepository.GetGymTrainerMembershipsByUserIdAsync(userId);
            return Ok(memberships);
        }

        [HttpGet("trainer/{trainerId}")]
        public async Task<ActionResult<IEnumerable<GymTrainerMembership>>> GetGymTrainerMembershipsByTrainerId(int trainerId)
        {
            var memberships = await _gymTrainerMembershipRepository.GetGymTrainerMembershipsByTrainerIdAsync(trainerId);
            return Ok(memberships);
        }

        [HttpPost]
        public async Task<ActionResult<GymTrainerMembership>> CreateGymTrainerMembership([FromBody] GymTrainerMembership membership)
        {
            var createdMembership = await _gymTrainerMembershipRepository.CreateGymTrainerMembershipAsync(membership);
            return CreatedAtAction(nameof(GetGymTrainerMembershipById), new { id = createdMembership.GymTrainerMembershipId }, createdMembership);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGymTrainerMembership(int id, [FromBody] GymTrainerMembership membership)
        {
            if (id != membership.GymTrainerMembershipId)
            {
                return BadRequest();
            }

            var updatedMembership = await _gymTrainerMembershipRepository.UpdateGymTrainerMembershipAsync(membership);
            if (updatedMembership == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymTrainerMembership(int id)
        {
            var result = await _gymTrainerMembershipRepository.DeleteGymTrainerMembershipAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 