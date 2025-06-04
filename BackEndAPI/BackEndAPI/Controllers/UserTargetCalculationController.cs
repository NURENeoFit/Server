using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;
using BackEndAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTargetCalculationController : ControllerBase
    {
        private readonly IUserTargetCalculationRepository _userTargetCalculationRepository;
        public UserTargetCalculationController(IUserTargetCalculationRepository userTargetCalculationRepository)
        {
            _userTargetCalculationRepository = userTargetCalculationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTargetCalculation>>> GetAllUserTargetCalculations()
        {
            var calculations = await _userTargetCalculationRepository.GetAllAsync();
            return Ok(calculations);
        }

        [HttpGet("{goalId}")]
        public async Task<ActionResult<UserTargetCalculation>> GetUserTargetCalculationById(int goalId)
        {
            var calculation = await _userTargetCalculationRepository.GetByIdAsync(goalId);
            if (calculation == null)
            {
                return NotFound();
            }
            return Ok(calculation);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserTargetCalculation>> GetAllTargetsByPersonalUserId(int personalUserDataId)
        {
            var calculation = await _userTargetCalculationRepository.GetAllTargetsByPersonalUserDataIdAsync(personalUserDataId);
            if (calculation == null)
            {
                return NotFound();
            }
            return Ok(calculation);
        }

        [HttpPost]
        public async Task<ActionResult<UserTargetCalculation>> CreateUserTargetCalculation([FromBody] UserTargetCalculation userTargetCalculation)
        {
            await _userTargetCalculationRepository.AddAsync(userTargetCalculation);
            await _userTargetCalculationRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUserTargetCalculationById), new { userId = userTargetCalculation.UserId }, userTargetCalculation);
        }

        [HttpPut("{goalId}")]
        public async Task<IActionResult> UpdateUserTargetCalculation(int goalId, [FromBody] UserTargetCalculation updateUserTargetCalculation)
        {
            var existingCalculation = await _userTargetCalculationRepository.GetByIdAsync(goalId);
            if (existingCalculation == null)
            {
                return NotFound();
            }
            existingCalculation.CalculatedNormalCalories = updateUserTargetCalculation.CalculatedNormalCalories;
            existingCalculation.CalculatedWeight = updateUserTargetCalculation.CalculatedWeight;
            existingCalculation.CalculatedTargetDate = updateUserTargetCalculation.CalculatedTargetDate;

            _userTargetCalculationRepository.Update(existingCalculation);
            await _userTargetCalculationRepository.SaveAsync();

            return Ok(existingCalculation);
        }

        [HttpDelete("{goalId}")]
        public async Task<IActionResult> DeleteUserTargetCalculation(int goalId)
        {
            var existingCalculation = await _userTargetCalculationRepository.GetByIdAsync(goalId);
            if (existingCalculation == null)
            {
                return NotFound();
            }
            _userTargetCalculationRepository.Delete(existingCalculation);
            await _userTargetCalculationRepository.SaveAsync();
            return NoContent();
        }
    }
}
