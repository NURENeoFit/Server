using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        Task<IEnumerable<Exercise>> GetAllExercisesByWorkOutProgramId(int workoutProgramId);
    }
} 