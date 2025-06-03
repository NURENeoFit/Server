using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessCenterRepository : GenericRepository<FitnessCenter>, IFitnessCenterRepository
    {
        public FitnessCenterRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<FitnessCenter>> GetAllFitnessCentersByComplexIdAsync(int sportComplexId)
        {
            return await _context.FitnessCenters
                .Where(fc => fc.SportComplexId == sportComplexId)
                .ToListAsync();
        }
    }
} 