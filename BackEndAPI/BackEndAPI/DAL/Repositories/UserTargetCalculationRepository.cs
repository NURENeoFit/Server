using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class UserTargetCalculationRepository : GenericRepository<UserTargetCalculation>, IUserTargetCalculationRepository
    {
        public UserTargetCalculationRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserTargetCalculation>> GetAllTargetsByPersonalUserDataIdAsync(int personalUserDataId)
        {
            return await _context.UserTargetCalculations
                .Where(tc => tc.UserId == personalUserDataId)
                .ToListAsync();
        }
    }
} 