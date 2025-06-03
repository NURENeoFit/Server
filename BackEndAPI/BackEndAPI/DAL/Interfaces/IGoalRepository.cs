using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGoalRepository : IGenericRepository<Goal>
    {
        Task<IEnumerable<Goal>> GetAllGoalsByTypeAsync(GoalType goalType);
    }
} 