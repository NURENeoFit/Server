using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Models;
using BackEndAPI.Services;
using System.Collections.Generic;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserTrainingController : ControllerBase
    {
        private readonly IGroupTrainingBookingRepository _groupTrainingBookingRepository;
        private readonly IFitnessMembershipBookingRepository _fitnessMembershipBookingRepository;
        private readonly JwtService _jwtService;

        public UserTrainingController(
            IGroupTrainingBookingRepository groupTrainingBookingRepository,
            IFitnessMembershipBookingRepository fitnessMembershipBookingRepository,
            JwtService jwtService)
        {
            _groupTrainingBookingRepository = groupTrainingBookingRepository;
            _fitnessMembershipBookingRepository = fitnessMembershipBookingRepository;
            _jwtService = jwtService;
        }

        [HttpGet("calendar")]
        public async Task<ActionResult<IEnumerable<TrainingResponse>>> GetTrainingCalendar()
        {
            var userId = _jwtService.GetUserIdFromToken(User);

            // Проверяем наличие действующей подписки на фитнес
            var fitnessMemberships = await _fitnessMembershipBookingRepository.GetFitnessMembershipBookingsByUserIdAsync(userId);
            var activeFitnessMembership = fitnessMemberships
                .FirstOrDefault(m => m.StartDate <= DateTime.UtcNow && m.EndDate >= DateTime.UtcNow);

            if (activeFitnessMembership == null)
            {
                return Ok(new List<TrainingResponse>()); // Возвращаем пустой список, если нет активной подписки
            }

            // Получаем все бронирования групповых тренировок
            var bookings = await _groupTrainingBookingRepository.GetAllBookingsByUserIdAsync(userId);

            // Преобразуем в формат ответа
            var response = bookings.Select(b => new TrainingResponse
            {
                SpecializationName = b.GroupSchedule.GroupTraining.Specialization.Name,
                FitnessRoomName = b.GroupSchedule.FitnessRoom.Name,
                Date = b.GroupSchedule.Date.ToString("yyyy-MM-dd"),
                StartTime = b.GroupSchedule.StartTime.ToString("HH:mm"),
                EndTime = b.GroupSchedule.EndTime.ToString("HH:mm"),
                FullNameTrainer = $"{b.GroupSchedule.FitnessTrainer.User.FirstName} {b.GroupSchedule.FitnessTrainer.User.LastName}"
            });

            return Ok(response);
        }
    }
} 