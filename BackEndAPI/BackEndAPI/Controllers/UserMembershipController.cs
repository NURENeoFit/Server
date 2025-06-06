using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Models;
using BackEndAPI.Entities.Enums;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserMembershipController : ControllerBase
    {
        private readonly IFitnessMembershipBookingRepository _fitnessMembershipBookingRepository;
        private readonly IGymMembershipBookingRepository _gymMembershipBookingRepository;
        private readonly IGymTrainerMembershipBookingRepository _gymTrainerMembershipBookingRepository;

        public UserMembershipController(
            IFitnessMembershipBookingRepository fitnessMembershipBookingRepository,
            IGymMembershipBookingRepository gymMembershipBookingRepository,
            IGymTrainerMembershipBookingRepository gymTrainerMembershipBookingRepository)
        {
            _fitnessMembershipBookingRepository = fitnessMembershipBookingRepository;
            _gymMembershipBookingRepository = gymMembershipBookingRepository;
            _gymTrainerMembershipBookingRepository = gymTrainerMembershipBookingRepository;
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<MembershipResponse>>> GetActiveMemberships()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentDate = DateTime.UtcNow;

            var activeMemberships = new List<MembershipResponse>();

            // Получаем активные фитнес-членства с полной информацией
            var fitnessBookings = await _fitnessMembershipBookingRepository.GetFitnessMembershipBookingsByUserIdAsync(userId);
            var activeFitnessMemberships = fitnessBookings
                .Where(b => b.StartDate <= currentDate && b.EndDate >= currentDate)
                .Select(b => new MembershipResponse
                {
                    Price = b.Membership.MembershipPrice,
                    Name = b.Membership.MembershipName,
                    Description = b.Membership.MembershipDescription,
                    MembershipType = MembershipType.Fitness,
                    StartDate = b.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = b.EndDate.ToString("yyyy-MM-dd")
                });
            activeMemberships.AddRange(activeFitnessMemberships);

            // Получаем активные тренажерные членства с полной информацией
            var gymBookings = await _gymMembershipBookingRepository.GetGymMembershipBookingsByUserIdAsync(userId);
            var activeGymMemberships = gymBookings
                .Where(b => b.StartDate <= currentDate && b.EndDate >= currentDate)
                .Select(b => new MembershipResponse
                {
                    Price = b.Membership.MembershipPrice,
                    Name = b.Membership.MembershipName,
                    Description = b.Membership.MembershipDescription,
                    MembershipType = MembershipType.Gym,
                    StartDate = b.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = b.EndDate.ToString("yyyy-MM-dd")
                });
            activeMemberships.AddRange(activeGymMemberships);

            // Получаем активные членства с тренером с полной информацией
            var gymTrainerBookings = await _gymTrainerMembershipBookingRepository.GetGymTrainerMembershipBookingsByUserIdAsync(userId);
            var activeGymTrainerMemberships = gymTrainerBookings
                .Where(b => b.StartDate <= currentDate && b.EndDate >= currentDate)
                .Select(b => new MembershipResponse
                {
                    Price = b.Membership.MembershipPrice,
                    Name = b.Membership.MembershipName,
                    Description = b.Membership.MembershipDescription,
                    MembershipType = MembershipType.GymTrainer,
                    StartDate = b.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = b.EndDate.ToString("yyyy-MM-dd")
                });
            activeMemberships.AddRange(activeGymTrainerMemberships);

            return Ok(activeMemberships);
        }
    }
} 