using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportComplexController : ControllerBase
    {
        private readonly ISportComplexRepository _sportComplexRepository;

        public SportComplexController(ISportComplexRepository sportComplexRepository)
        {
            _sportComplexRepository = sportComplexRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SportComplex>> GetSportComplexById(int id)
        {
            var complex = await _sportComplexRepository.GetByIdAsync(id);
            if (complex == null)
                return NotFound();

            return Ok(complex);
        }

        [HttpPost]
        public async Task<ActionResult<SportComplex>> CreateSportComplex([FromBody] SportComplex sportComplex)
        {
            await _sportComplexRepository.AddAsync(sportComplex);
            await _sportComplexRepository.SaveAsync();

            return CreatedAtAction(nameof(GetSportComplexById), new { id = sportComplex.SportComplexId }, sportComplex);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSportComplex(int id, [FromBody] SportComplex updated)
        {
            var existing = await _sportComplexRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.SportComplexName = updated.SportComplexName;
            existing.Address = updated.Address;

            _sportComplexRepository.Update(existing);
            await _sportComplexRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportComplex(int id)
        {
            var complex = await _sportComplexRepository.GetByIdAsync(id);
            if (complex == null)
                return NotFound();

            var hasFitnessCenters = await _sportComplexRepository.GetFitnessCentersBySportComplexIdAsync(id);
            var hasGymCenters = await _sportComplexRepository.GetGymCentersBySportComplexIdAsync(id);

            if ((hasFitnessCenters?.Any() ?? false) || (hasGymCenters?.Any() ?? false))
            {
                return BadRequest("Cannot delete a spotrs complex that has fitness or gym centers.");
            }

            _sportComplexRepository.Delete(complex);
            await _sportComplexRepository.SaveAsync();
            return NoContent();
        }
    }
}

