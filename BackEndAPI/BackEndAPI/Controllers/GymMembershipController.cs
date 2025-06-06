using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymMembershipController : ControllerBase
    {
        private readonly IGymMembershipRepository _gymMembershipRepository;

        public GymMembershipController(IGymMembershipRepository gymMembershipRepository)
        {
            _gymMembershipRepository = gymMembershipRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymMembership>>> GetAllGymMemberships()
        {
            var memberships = await _gymMembershipRepository.GetAllGymMembershipsAsync();
            return Ok(memberships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymMembership>> GetGymMembershipById(int id)
        {
            var membership = await _gymMembershipRepository.GetGymMembershipByIdAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return Ok(membership);
        }

        [HttpGet("gym-center/{gymCenterId}")]
        public async Task<ActionResult<IEnumerable<GymMembership>>> GetGymMembershipsByGymCenterId(int gymCenterId)
        {
            var memberships = await _gymMembershipRepository.GetGymMembershipsByGymCenterIdAsync(gymCenterId);
            return Ok(memberships);
        }

        //[HttpPost]
        //public async Task<ActionResult<GymMembership>> CreateGymMembership([FromBody] GymMembership membership)
        //{
        //    var createdMembership = await _gymMembershipRepository.CreateGymMembershipAsync(membership);
        //    return CreatedAtAction(nameof(GetGymMembershipById), new { id = createdMembership.GymMembershipId }, createdMembership);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateGymMembership(int id, [FromBody] GymMembership membership)
        //{
        //    if (id != membership.GymMembershipId)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedMembership = await _gymMembershipRepository.UpdateGymMembershipAsync(membership);
        //    if (updatedMembership == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymMembership(int id)
        {
            var result = await _gymMembershipRepository.DeleteGymMembershipAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 