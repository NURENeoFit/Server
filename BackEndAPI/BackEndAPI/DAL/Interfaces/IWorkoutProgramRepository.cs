using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IWorkoutProgramRepository : IGenericRepository<WorkoutProgram>
    {
        Task<IEnumerable<Exercise>> GetExercisesByWorkoutProgramIdAsync(int workoutProgramId);
    }
} 