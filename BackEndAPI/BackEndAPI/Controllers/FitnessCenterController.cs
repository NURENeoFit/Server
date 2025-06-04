using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FitnessCenterController : ControllerBase
    {
        private readonly IFitnessCenterRepository _fitnessCenterRepository;
        private readonly IGenericRepository<FitnessMembership> _fitnessMembershipRepository;
        private readonly IGenericRepository<FitnessRoom> _fitnessRoomRepository;

        public FitnessCenterController(
            IFitnessCenterRepository fitnessCenterRepository,
            IGenericRepository<FitnessMembership> fitnessMembershipRepository,
            IGenericRepository<FitnessRoom> fitnessRoomRepository)
        {
            _fitnessCenterRepository = fitnessCenterRepository;
            _fitnessMembershipRepository = fitnessMembershipRepository;
            _fitnessRoomRepository = fitnessRoomRepository;
        }

        [HttpGet("by-complex/{sportComplexId}")]
        public async Task<ActionResult<IEnumerable<FitnessCenter>>> GetAllBySportComplex(int sportComplexId)
        {
            var centers = await _fitnessCenterRepository.GetAllFitnessCentersByComplexIdAsync(sportComplexId);
            return Ok(centers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessCenter>> GetById(int id)
        {
            var center = await _fitnessCenterRepository.GetByIdAsync(id);
            if (center == null)
                return NotFound();
            return Ok(center);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessCenter>> Create([FromBody] FitnessCenter center)
        {
            await _fitnessCenterRepository.AddAsync(center);
            await _fitnessCenterRepository.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = center.FitnessCenterId }, center);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FitnessCenter updated)
        {
            var existing = await _fitnessCenterRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.FitnessCenterName = updated.FitnessCenterName;
            existing.SportComplexId = updated.SportComplexId;

            _fitnessCenterRepository.Update(existing);
            await _fitnessCenterRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var center = await _fitnessCenterRepository.GetByIdAsync(id);
            if (center == null)
                return NotFound();

            var memberships = await _fitnessMembershipRepository.GetAllAsync();
            var hasMemberships = memberships.Any(m => m.FitnessCenterId == id);

            var rooms = await _fitnessRoomRepository.GetAllAsync();
            var hasRooms = rooms.Any(r => r.FitnessCenterId == id);


            if (hasMemberships || hasRooms)
            {
                return BadRequest("Cannot delete a fitness center that has fitness rooms or memberships. ");
            }

            _fitnessCenterRepository.Delete(center);
            await _fitnessCenterRepository.SaveAsync();

            return NoContent();
        }
    }
}
