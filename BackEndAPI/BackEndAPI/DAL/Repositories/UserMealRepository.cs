using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class UserMealRepository : GenericRepository<UserMeal>, IUserMealRepository
    {
        public UserMealRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserMeal>> GetAllMealsByPersonalUserDataIdAsync(int personalUserDataId)
        {
            return await _context.UserMeals
                .Where(um => um.UserProfileId == personalUserDataId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserMeal>> GetAllMealsByPersonalUserDataIdAndDateAsync(int personalUserDataId, DateTime date)
        {
            return await _context.UserMeals
                .Where(um => um.UserProfileId == personalUserDataId && um.CreatedTime.Date == date.Date)
                .ToListAsync();
        }
    }
} 