using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IUserMealRepository : IGenericRepository<UserMeal>
    {
        Task<IEnumerable<UserMeal>> GetAllMealsByPersonalUserDataIdAsync(int personalUserDataId);
        Task<IEnumerable<UserMeal>> GetAllMealsByPersonalUserDataIdAndDateAsync(int personalUserDataId, DateTime date);
    }
} 