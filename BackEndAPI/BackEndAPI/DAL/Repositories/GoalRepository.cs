using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        public GoalRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramsByGoalIdAsync(int goalId)
        {
            return await _context.WorkoutPrograms
                .Where(wp => wp.ProgramGoalId == goalId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PersonalUserData>> GetPersonalUserDataByGoalIdAsync(int goalId)
        {
            return await _context.PersonalUserData
                .Where(pud => pud.GoalId == goalId)
                .ToListAsync();
        }
    }
} 