using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramsByTrainerIdAsync(int trainerId)
        {
            return await _context.WorkoutPrograms
                .Where(wp => wp.TrainerId == trainerId)
                .ToListAsync();
        }
    }
} 