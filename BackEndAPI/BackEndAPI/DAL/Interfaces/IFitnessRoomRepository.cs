using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IFitnessRoomRepository : IGenericRepository<FitnessRoom>
    {
        Task<IEnumerable<FitnessRoom>> GetAllFitnessRoomsByFitnessCenterIdAsync(int fitnessCenterId);
    }
} 