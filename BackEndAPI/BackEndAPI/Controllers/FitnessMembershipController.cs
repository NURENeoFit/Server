using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FitnessMembershipController : ControllerBase
    {
        private readonly IFitnessMembershipRepository _fitnessMembershipRepository;

        public FitnessMembershipController(IFitnessMembershipRepository fitnessMembershipRepository)
        {
            _fitnessMembershipRepository = fitnessMembershipRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessMembership>>> GetAllFitnessMemberships()
        {
            var memberships = await _fitnessMembershipRepository.GetAllFitnessMembershipsAsync();
            return Ok(memberships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessMembership>> GetFitnessMembershipById(int id)
        {
            var membership = await _fitnessMembershipRepository.GetFitnessMembershipByIdAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return Ok(membership);
        }


        [HttpGet("fitness-center/{fitnessCenterId}")]
        public async Task<ActionResult<IEnumerable<FitnessMembership>>> GetFitnessMembershipsByFitnessCenterId(int fitnessCenterId)
        {
            var memberships = await _fitnessMembershipRepository.GetFitnessMembershipsByFitnessCenterIdAsync(fitnessCenterId);
            return Ok(memberships);
        }

        [HttpPost]
        //public async Task<ActionResult<FitnessMembership>> CreateFitnessMembership([FromBody] FitnessMembership membership)
        //{
        //    var createdMembership = await _fitnessMembershipRepository.CreateFitnessMembershipAsync(membership);
        //    return CreatedAtAction(nameof(GetFitnessMembershipById), new { id = createdMembership.FitnessMembershipId }, createdMembership);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateFitnessMembership(int id, [FromBody] FitnessMembership membership)
        //{
        //    if (id != membership.FitnessMembershipId)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedMembership = await _fitnessMembershipRepository.UpdateFitnessMembershipAsync(membership);
        //    if (updatedMembership == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessMembership(int id)
        {
            var result = await _fitnessMembershipRepository.DeleteFitnessMembershipAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 