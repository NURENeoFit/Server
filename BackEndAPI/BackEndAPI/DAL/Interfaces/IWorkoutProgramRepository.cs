using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IWorkoutProgramRepository : IGenericRepository<WorkoutProgram>
    {
        Task<IEnumerable<WorkoutProgram>> GetAllWorkoutsByGoalAsync(int goalId);
        Task<IEnumerable<WorkoutProgram>> GetAllWorkoutsByTypeAsync(ProgramType type);
        Task<IEnumerable<WorkoutProgram>> GetAllWorkoutProgramsByTrainerIdAsync(int trainerId);
    }
} 