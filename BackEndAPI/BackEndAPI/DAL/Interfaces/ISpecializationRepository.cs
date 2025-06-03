using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface ISpecializationRepository : IGenericRepository<Specialization>
    {
        Task<IEnumerable<Specialization>> GetSpecializationsByTrainerIdAsync(int trainerId);
    }
} 