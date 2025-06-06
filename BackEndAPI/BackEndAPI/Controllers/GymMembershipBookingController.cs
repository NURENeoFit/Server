using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymMembershipBookingController : ControllerBase
    {
        private readonly IGymMembershipBookingRepository _gymMembershipBookingRepository;

        public GymMembershipBookingController(IGymMembershipBookingRepository gymMembershipBookingRepository)
        {
            _gymMembershipBookingRepository = gymMembershipBookingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymMembershipBooking>>> GetAllGymMembershipBookings()
        {
            var bookings = await _gymMembershipBookingRepository.GetAllGymMembershipBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymMembershipBooking>> GetGymMembershipBookingById(int id)
        {
            var booking = await _gymMembershipBookingRepository.GetGymMembershipBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GymMembershipBooking>>> GetGymMembershipBookingsByUserId(int userId)
        {
            var bookings = await _gymMembershipBookingRepository.GetGymMembershipBookingsByUserIdAsync(userId);
            return Ok(bookings);
        }

        [HttpGet("membership/{gymMembershipId}")]
        public async Task<ActionResult<IEnumerable<GymMembershipBooking>>> GetGymMembershipBookingsByMembershipId(int gymMembershipId)
        {
            var bookings = await _gymMembershipBookingRepository.GetGymMembershipBookingsByGymMembershipIdAsync(gymMembershipId);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<GymMembershipBooking>> CreateGymMembershipBooking([FromBody] GymMembershipBooking booking)
        {
            var createdBooking = await _gymMembershipBookingRepository.CreateGymMembershipBookingAsync(booking);
            return CreatedAtAction(nameof(GetGymMembershipBookingById), new { id = createdBooking.GymMembershipBookingId }, createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGymMembershipBooking(int id, [FromBody] GymMembershipBooking booking)
        {
            if (id != booking.GymMembershipBookingId)
            {
                return BadRequest();
            }

            var updatedBooking = await _gymMembershipBookingRepository.UpdateGymMembershipBookingAsync(booking);
            if (updatedBooking == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymMembershipBooking(int id)
        {
            var result = await _gymMembershipBookingRepository.DeleteGymMembershipBookingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 