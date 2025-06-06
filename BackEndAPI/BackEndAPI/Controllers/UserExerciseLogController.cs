using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserExerciseLogController : ControllerBase
    {
        private readonly IUserExerciseLogRepository _userExerciseLogRepository;

        public UserExerciseLogController(IUserExerciseLogRepository userExerciseLogRepository)
        {
            _userExerciseLogRepository = userExerciseLogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserExerciseLog>>> GetAllUserExerciseLogs()
        {
            var logs = await _userExerciseLogRepository.GetAllAsync();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserExerciseLog>> GetUserExerciseLogById(int id)
        {
            var log = await _userExerciseLogRepository.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        [HttpPost]
        public async Task<ActionResult<UserExerciseLog>> CreateUserExerciseLog([FromBody] UserExerciseLog log)
        {
            await _userExerciseLogRepository.AddAsync(log);
            await _userExerciseLogRepository.SaveAsync();
            return CreatedAtAction(nameof(GetUserExerciseLogById), new { id = log.UserExerciseLogId }, log);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserExerciseLog(int id, [FromBody] UserExerciseLog log)
        {
            if (id != log.UserExerciseLogId)
            {
                return BadRequest();
            }

            var existingLog = await _userExerciseLogRepository.GetByIdAsync(id);
            if (existingLog == null)
            {
                return NotFound();
            }

            _userExerciseLogRepository.Update(log);
            await _userExerciseLogRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserExerciseLog(int id)
        {
            var log = await _userExerciseLogRepository.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }

            _userExerciseLogRepository.Delete(log);
            await _userExerciseLogRepository.SaveAsync();

            return NoContent();
        }
    }
} 