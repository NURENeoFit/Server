using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class WorkingTimeRepository : GenericRepository<WorkingTime>, IWorkingTimeRepository
    {
        public WorkingTimeRepository(AppDbContext context) : base(context) { }
        
        public async Task<IEnumerable<WorkingTime>> GetAllSchedulesBySportComplexIdAsync(int sportComplexId)
        {
            return await _context.WorkingTimes
                .Where(wt => wt.SportComplexId == sportComplexId)
                .OrderBy(wt => wt.DayOfWeek)
                .ToListAsync();
        }

        public async Task<WorkingTime> GetScheduleByDayAsync(int sportComplexId, string dayOfWeek)
        {
            return await _context.WorkingTimes
                .FirstOrDefaultAsync(wt => wt.SportComplexId == sportComplexId && wt.DayOfWeek == dayOfWeek);
        }

        public async Task<bool> AddScheduleAsync(WorkingTime workingTime)
        {
            var exists = await IsScheduleExistsForDayAsync(workingTime.SportComplexId, workingTime.DayOfWeek);
            if (exists)
            {
                return false;
            }

            await _context.WorkingTimes.AddAsync(workingTime);
            await _context.SaveChangesAsync();
            return true;
        }

 
        private async Task<bool> IsScheduleExistsForDayAsync(int sportComplexId, string dayOfWeek)
        {
            return await _context.WorkingTimes
                .AnyAsync(wt => wt.SportComplexId == sportComplexId && wt.DayOfWeek == dayOfWeek);
        }
    }
} 