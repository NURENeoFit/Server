using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GroupTrainingBookingRepository : GenericRepository<GroupTrainingBooking>, IGroupTrainingBookingRepository
    {
        public GroupTrainingBookingRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<GroupTrainingBooking>> GetAllBookingsByUserIdAsync(int userId)
        {
            return await _context.GroupTrainingBookings
                .Include(gtb => gtb.User)
                .Include(gtb => gtb.GroupSchedule)
                    .ThenInclude(gs => gs.GroupTraining)
                .Include(gtb => gtb.GroupSchedule)
                    .ThenInclude(gs => gs.FitnessTrainer)
                .Where(gtb => gtb.UserId == userId)
                .OrderBy(gtb => gtb.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupTrainingBooking>> GetAllBookingsByGroupScheduleIdAsync(int groupScheduleId)
        {
            return await _context.GroupTrainingBookings
                .Include(gtb => gtb.User)
                .Include(gtb => gtb.GroupSchedule)
                    .ThenInclude(gs => gs.GroupTraining)
                .Include(gtb => gtb.GroupSchedule)
                    .ThenInclude(gs => gs.FitnessTrainer)
                .Where(gtb => gtb.GroupScheduleId == groupScheduleId)
                .OrderBy(gtb => gtb.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupTrainingBooking>> GetAllBookingsByGroupScheduleAndUserAsync(int groupScheduleId, int userId)
        {
            return await _context.GroupTrainingBookings
                .Include(gtb => gtb.User)
                .Include(gtb => gtb.GroupSchedule)
                    .ThenInclude(gs => gs.GroupTraining)
                .Include(gtb => gtb.GroupSchedule)
                    .ThenInclude(gs => gs.FitnessTrainer)
                .Where(gtb => gtb.GroupScheduleId == groupScheduleId && gtb.UserId == userId)
                .OrderBy(gtb => gtb.BookingDate)
                .ToListAsync();
        }
    }
} 