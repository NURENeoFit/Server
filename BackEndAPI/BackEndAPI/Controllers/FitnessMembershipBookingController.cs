using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FitnessMembershipBookingController : ControllerBase
    {
        private readonly IFitnessMembershipBookingRepository _fitnessMembershipBookingRepository;

        public FitnessMembershipBookingController(IFitnessMembershipBookingRepository fitnessMembershipBookingRepository)
        {
            _fitnessMembershipBookingRepository = fitnessMembershipBookingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessMembershipBooking>>> GetAllFitnessMembershipBookings()
        {
            var bookings = await _fitnessMembershipBookingRepository.GetAllFitnessMembershipBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessMembershipBooking>> GetFitnessMembershipBookingById(int id)
        {
            var booking = await _fitnessMembershipBookingRepository.GetFitnessMembershipBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<FitnessMembershipBooking>>> GetFitnessMembershipBookingsByUserId(int userId)
        {
            var bookings = await _fitnessMembershipBookingRepository.GetFitnessMembershipBookingsByUserIdAsync(userId);
            return Ok(bookings);
        }

        [HttpGet("membership/{fitnessMembershipId}")]
        public async Task<ActionResult<IEnumerable<FitnessMembershipBooking>>> GetFitnessMembershipBookingsByMembershipId(int fitnessMembershipId)
        {
            var bookings = await _fitnessMembershipBookingRepository.GetFitnessMembershipBookingsByFitnessMembershipIdAsync(fitnessMembershipId);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessMembershipBooking>> CreateFitnessMembershipBooking([FromBody] FitnessMembershipBooking booking)
        {
            var createdBooking = await _fitnessMembershipBookingRepository.CreateFitnessMembershipBookingAsync(booking);
            return CreatedAtAction(nameof(GetFitnessMembershipBookingById), new { id = createdBooking.FitnessMembershipBookingId }, createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFitnessMembershipBooking(int id, [FromBody] FitnessMembershipBooking booking)
        {
            if (id != booking.FitnessMembershipBookingId)
            {
                return BadRequest();
            }

            var updatedBooking = await _fitnessMembershipBookingRepository.UpdateFitnessMembershipBookingAsync(booking);
            if (updatedBooking == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessMembershipBooking(int id)
        {
            var result = await _fitnessMembershipBookingRepository.DeleteFitnessMembershipBookingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 