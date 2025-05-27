using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class WorkoutProgramRepository : GenericRepository<WorkoutProgram>, IWorkoutProgramRepository
    {
        public WorkoutProgramRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Exercise>> GetExercisesByWorkoutProgramIdAsync(int workoutProgramId)
        {
            return await _context.Exercises
                .Where(e => e.WorkoutProgramId == workoutProgramId)
                .ToListAsync();
        }
    }
} 