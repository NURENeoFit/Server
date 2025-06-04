using BackEndAPI.DAL.Interfaces;
using BackEndAPI.DAL.Repositories;
using BackEndAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMealController : ControllerBase
    {
        private readonly IUserMealRepository _userMealRepository;
        public UserMealController(IUserMealRepository userMealRepository)
        {
            _userMealRepository = userMealRepository;
        }

        [HttpGet("user/{userProfileId}")]
        public async Task<ActionResult> GetAllMealsByUser(int userProfileId)
        {
            var meals = await _userMealRepository.GetAllMealsByPersonalUserDataIdAsync(userProfileId);
            return Ok(meals);
        }

        [HttpGet("user/{userProfileId}/date/{date}")]
        public async Task<IActionResult> GetMealsByUserAndDate(int userProfileId, DateTime date)
        {
            var meals = await _userMealRepository.GetAllMealsByPersonalUserDataIdAndDateAsync(userProfileId, date);
            return Ok(meals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserMealById(int id)
        {
            var userMeal = await _userMealRepository.GetByIdAsync(id);
            if (userMeal == null)
            {
                return NotFound();
            }
            return Ok(userMeal);
        }

        [HttpPost]
        public async Task<ActionResult<UserMeal>> CreateUserMeal([FromBody] UserMeal userMeal)
        {
            await _userMealRepository.AddAsync(userMeal);
            await _userMealRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUserMealById), new { id = userMeal.UserMealId }, userMeal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserMeal(int id, [FromBody] UserMeal updateUserMeal)
        {
            var existingMeal = await _userMealRepository.GetByIdAsync(id);
            if (existingMeal == null)
            {
                return NotFound();
            }

            existingMeal.Type = updateUserMeal.Type;
            existingMeal.Calories = updateUserMeal.Calories;
            existingMeal.CreatedTime = updateUserMeal.CreatedTime;
            existingMeal.Notes = updateUserMeal.Notes;
            existingMeal.UserProfileId = updateUserMeal.UserProfileId;

            _userMealRepository.Update(existingMeal);
            await _userMealRepository.SaveAsync();

            return NoContent();
        }
    }
}
