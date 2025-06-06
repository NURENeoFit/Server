using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.DAL.Repositories
{
    public class WorkoutProgramRepository : GenericRepository<WorkoutProgram>, IWorkoutProgramRepository
    {
        public WorkoutProgramRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<WorkoutProgram>> GetAllWorkoutProgramsByTrainerIdAsync(int trainerId)
        {
            return await _context.WorkoutPrograms
                .Include(wp => wp.Trainer)
                .Include(wp => wp.Goal)
                .Include(wp => wp.Exercises)
                .Where(wp => wp.TrainerId == trainerId)
                .OrderBy(wp => wp.ProgramName)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkoutProgram>> GetAllWorkoutsByGoalAsync(int goalId)
        {
            return await _context.WorkoutPrograms
                .Include(wp => wp.Trainer)
                .Include(wp => wp.Goal)
                .Include(wp => wp.Exercises)
                .Where(wp => wp.ProgramGoalId == goalId)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkoutProgram>> GetAllWorkoutsByTypeAsync(ProgramType type)
        {
            return await _context.WorkoutPrograms
                .Include(wp => wp.Trainer)
                .Include(wp => wp.Goal)
                .Include(wp => wp.Exercises)
                .Where(wp => wp.ProgramType == type)
                .ToListAsync();
        }
    }
} 