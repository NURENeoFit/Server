using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IFitnessCenterRepository : IGenericRepository<FitnessCenter>
    {
        Task<IEnumerable<FitnessCenter>> GetAllFitnessCentersByComplexIdAsync(int sportComplexId);
    }
} 