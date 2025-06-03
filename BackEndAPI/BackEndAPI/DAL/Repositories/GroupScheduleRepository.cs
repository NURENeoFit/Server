using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GroupScheduleRepository : GenericRepository<GroupSchedule>, IGroupScheduleRepository
    {
        public GroupScheduleRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<GroupSchedule>> GetAllSchedulesByGroupTrainingIdAsync(int groupTrainingId)
        {
            return await _context.GroupSchedules
                .Include(gs => gs.FitnessTrainer)
                .Include(gs => gs.GroupTraining)
                .Where(gs => gs.GroupTrainingId == groupTrainingId)
                .OrderBy(gs => gs.DateOfDay)
                .ThenBy(gs => gs.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupSchedule>> GetAllSchedulesByFitnessTrainerIdAsync(int fitnessTrainerId)
        {
            return await _context.GroupSchedules
                .Include(gs => gs.FitnessTrainer)
                .Include(gs => gs.GroupTraining)
                .Where(gs => gs.FitnessTrainerId == fitnessTrainerId)
                .OrderBy(gs => gs.DateOfDay)
                .ThenBy(gs => gs.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupSchedule>> GetAllSchedulesByGroupTrainingAndTrainerAsync(int groupTrainingId, int fitnessTrainerId)
        {
            return await _context.GroupSchedules
                .Include(gs => gs.FitnessTrainer)
                .Include(gs => gs.GroupTraining)
                .Where(gs => gs.GroupTrainingId == groupTrainingId && gs.FitnessTrainerId == fitnessTrainerId)
                .OrderBy(gs => gs.DateOfDay)
                .ThenBy(gs => gs.StartTime)
                .ToListAsync();
        }
    }
} 