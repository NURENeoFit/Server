using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;
using BackEndAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PersonalUserDataController : ControllerBase
    {
        private readonly IPersonalUserDataRepository _personalUserDataRepository;
        public PersonalUserDataController(IPersonalUserDataRepository personalUserDataRepository)
        {
            _personalUserDataRepository = personalUserDataRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalUserData>>> GetAllPersonalUserData()
        {
            var personalData = await _personalUserDataRepository.GetAllAsync();
            return Ok(personalData);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalUserData>> GetPersonalUserDataById(int id)
        {
            var personalData = await _personalUserDataRepository.GetByIdAsync(id);
            if (personalData == null)
            {
                return NotFound();
            }
            return Ok(personalData);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<PersonalUserData>> GetPersonalUserDataByUserId(int userId)
        {
            var personalData = await _personalUserDataRepository.GetPersonalUserDataByUserIdAsync(userId);
            if (personalData == null)
            {
                return NotFound();
            }
            return Ok(personalData);
        }

        [HttpPost]
        public async Task<ActionResult<PersonalUserData>> CreatePersonalUserData([FromBody] PersonalUserData personalUserData)
        {
            await _personalUserDataRepository.AddAsync(personalUserData);
            await _personalUserDataRepository.SaveAsync();
            return CreatedAtAction(nameof(GetPersonalUserDataByUserId), new { userId = personalUserData.UserId }, personalUserData);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonalUserData(int id, [FromBody] PersonalUserData updatePersonalUserData)
        {
            var existingPersonalData = await _personalUserDataRepository.GetByIdAsync(id);
            if (existingPersonalData == null)
            {
                return NotFound();
            }

            existingPersonalData.WeightKg = updatePersonalUserData.WeightKg;
            existingPersonalData.HeightCm = updatePersonalUserData.HeightCm;
            existingPersonalData.Age = updatePersonalUserData.Age;
            existingPersonalData.Gender = updatePersonalUserData.Gender;
            existingPersonalData.ActivityLevel = updatePersonalUserData.ActivityLevel;
            existingPersonalData.GoalId = updatePersonalUserData.GoalId;
            existingPersonalData.UpdatedAt = DateTime.UtcNow;

            _personalUserDataRepository.Update(existingPersonalData);
            await _personalUserDataRepository.SaveAsync();

            return Ok(existingPersonalData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalUserData(int id)
        {
            var personalData = await _personalUserDataRepository.GetByIdAsync(id);
            if (personalData == null)
            {
                return NotFound();
            }

            _personalUserDataRepository.Delete(personalData);
            await _personalUserDataRepository.SaveAsync();
            return NoContent();
        }
    }
}
