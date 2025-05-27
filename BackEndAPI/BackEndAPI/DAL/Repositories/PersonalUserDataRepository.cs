using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class PersonalUserDataRepository : GenericRepository<PersonalUserData>, IPersonalUserDataRepository
    {
        public PersonalUserDataRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserMeal>> GetMealsByPersonalUserDataIdAsync(int personalUserDataId)
        {
            return await _context.UserMeals
                .Where(m => m.UserProfileId == personalUserDataId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserTargetCalculation>> GetTargetCalculationsByPersonalUserDataIdAsync(int personalUserDataId)
        {
            return await _context.UserTargetCalculations
                .Where(tc => tc.UserId == personalUserDataId)
                .ToListAsync();
        }
    }
} 