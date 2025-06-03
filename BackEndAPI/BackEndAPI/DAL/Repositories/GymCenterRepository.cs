using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymCenterRepository : GenericRepository<GymCenter>, IGymCenterRepository
    {
        public GymCenterRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Gym>> GetAllGymsByComplexIdAsync(int sportComplexId)
        {
            return await _context.Gyms
                .Include(g => g.GymCenter)
                .Where(g => g.GymCenter.SportComplexId == sportComplexId)
                .ToListAsync();
        }
    }
} 