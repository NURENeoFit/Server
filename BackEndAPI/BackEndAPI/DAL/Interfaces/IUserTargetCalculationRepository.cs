using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IUserTargetCalculationRepository : IGenericRepository<UserTargetCalculation>
    {
        Task<IEnumerable<UserTargetCalculation>> GetAllTargetsByPersonalUserDataIdAsync(int personalUserDataId);
    }
} 