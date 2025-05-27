using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramsByTrainerIdAsync(int trainerId);
    }
} 