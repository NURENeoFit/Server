using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;
using BackEndAPI.Entities.Enums;

namespace BackEndAPI.DAL.Repositories
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        public GoalRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Goal>> GetAllGoalsByTypeAsync(GoalType goalType)
        {
            return await _context.Goals
                .Where(g => g.GoalType == goalType)
                .ToListAsync();
        }
    }
} 