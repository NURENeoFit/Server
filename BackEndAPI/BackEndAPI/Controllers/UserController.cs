using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;
using BackEndAPI.Models;
using BackEndAPI.Services;
using System.Security.Cryptography;
using System.Text;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public UserController(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("role/{roleId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByRole(int roleId)
        {
            var users = await _userRepository.GetUsersByRoleIdAsync(roleId);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updateUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.FirstName = updateUser.FirstName;
            existingUser.LastName = updateUser.LastName;
            existingUser.Email = updateUser.Email;
            existingUser.Phone = updateUser.Phone;
            existingUser.Username = updateUser.Username;
            existingUser.HashPassword = updateUser.HashPassword;
            existingUser.RoleId = updateUser.RoleId;
            existingUser.DateOfBirth = updateUser.DateOfBirth;
            existingUser.UpdatedAt = DateTime.UtcNow;

            _userRepository.Update(existingUser);
            await _userRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var user = (await _userRepository.FindAsync(u => u.Username == request.Username)).FirstOrDefault();
            
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Хешируем введенный пароль для сравнения с хешем в базе
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                var hashedPassword = Convert.ToBase64String(hashedBytes);

                if (user.HashPassword != hashedPassword)
                {
                    return Unauthorized(new { message = "Invalid username or password" });
                }
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new LoginResponse
            {
                Token = token,
                Username = user.Username,
                UserId = user.UserId,
            });
        }
    }
}
