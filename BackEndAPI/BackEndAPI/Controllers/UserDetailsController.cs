using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Models;
using BackEndAPI.Services;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonalUserDataRepository _personalUserDataRepository;
        private readonly JwtService _jwtService;

        public UserDetailsController(
            IUserRepository userRepository,
            IPersonalUserDataRepository personalUserDataRepository,
            JwtService jwtService)
        {
            _userRepository = userRepository;
            _personalUserDataRepository = personalUserDataRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailsResponse>> GetUserDetails()
        {
            var userId = _jwtService.GetUserIdFromToken(User);
            if (userId == 0)
            {
                return Unauthorized();
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var personalData = await _personalUserDataRepository.GetPersonalUserDataByUserIdAsync(userId);

            var response = new UserDetailsResponse
            {
                User = new UserInfo
                {
                    UserFirstName = user.FirstName,
                    UserLastName = user.LastName,
                    Username = user.Username,
                    UserPhone = user.Phone,
                    UserEmail = user.Email,
                    UserDob = user.DateOfBirth.ToString("yyyy-MM-dd")
                }
            };

            if (personalData != null)
            {
                response.PersonalData = new PersonalDataInfo
                {
                    WeightKg = (double)personalData.WeightKg,
                    HeightCm = (int)personalData.HeightCm,
                    Age = personalData.Age,
                    Gender = personalData.Gender.ToString(),
                    ActivityLevel = personalData.ActivityLevel.ToString(),
                    Goal = personalData.Goal != null ? new GoalInfo
                    {
                        GoalType = personalData.Goal.GoalType.ToString(),
                        Description = personalData.Goal.Description
                    } : null
                };
            }

            return Ok(response);
        }
    }
} 