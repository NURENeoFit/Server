using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface ISportComplexRepository : IGenericRepository<SportComplex>
    {
        Task<IEnumerable<WorkingTime>> GetWorkingTimesBySportComplexIdAsync(int sportComplexId);
        Task<IEnumerable<FitnessCenter>> GetFitnessCentersBySportComplexIdAsync(int sportComplexId);
        Task<IEnumerable<GymCenter>> GetGymCentersBySportComplexIdAsync(int sportComplexId);
    }
} 