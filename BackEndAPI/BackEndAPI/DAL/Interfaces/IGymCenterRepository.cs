using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGymCenterRepository : IGenericRepository<GymCenter>
    {
        Task<IEnumerable<Gym>> GetAllGymsByComplexIdAsync(int sportComplexId);
    }
} 