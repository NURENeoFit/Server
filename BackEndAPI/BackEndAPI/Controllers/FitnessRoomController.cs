using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FitnessRoomController : ControllerBase
    {
        private readonly IFitnessRoomRepository _fitnessRoomRepository;

        public FitnessRoomController(IFitnessRoomRepository fitnessRoomRepository)
        {
            _fitnessRoomRepository = fitnessRoomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessRoom>>> GetAllFitnessRooms()
        {
            var rooms = await _fitnessRoomRepository.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessRoom>> GetFitnessRoomById(int id)
        {
            var room = await _fitnessRoomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpGet("fitness-center/{fitnessCenterId}")]
        public async Task<ActionResult<IEnumerable<FitnessRoom>>> GetFitnessRoomsByFitnessCenterId(int fitnessCenterId)
        {
            var rooms = await _fitnessRoomRepository.GetAllFitnessRoomsByFitnessCenterIdAsync(fitnessCenterId);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessRoom>> CreateFitnessRoom([FromBody] FitnessRoom room)
        {
            await _fitnessRoomRepository.AddAsync(room);
            await _fitnessRoomRepository.SaveAsync();
            return CreatedAtAction(nameof(GetFitnessRoomById), new { id = room.FitnessRoomId }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFitnessRoom(int id, [FromBody] FitnessRoom room)
        {
            if (id != room.FitnessRoomId)
            {
                return BadRequest();
            }

            var existingRoom = await _fitnessRoomRepository.GetByIdAsync(id);
            if (existingRoom == null)
            {
                return NotFound();
            }

            _fitnessRoomRepository.Update(room);
            await _fitnessRoomRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessRoom(int id)
        {
            var room = await _fitnessRoomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _fitnessRoomRepository.Delete(room);
            await _fitnessRoomRepository.SaveAsync();

            return NoContent();
        }
    }
} 