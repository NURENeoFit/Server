using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGoalRepository : IGenericRepository<Goal>
    {
        Task<IEnumerable<WorkoutProgram>> GetWorkoutProgramsByGoalIdAsync(int goalId);
        Task<IEnumerable<PersonalUserData>> GetPersonalUserDataByGoalIdAsync(int goalId);
    }
} 