using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class SportComplexRepository : GenericRepository<SportComplex>, ISportComplexRepository
    {
        public SportComplexRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<WorkingTime>> GetWorkingTimesBySportComplexIdAsync(int sportComplexId)
        {
            return await _context.WorkingTimes
                .Where(wt => wt.SportComplexId == sportComplexId)
                .ToListAsync();
        }

        public async Task<IEnumerable<FitnessCenter>> GetFitnessCentersBySportComplexIdAsync(int sportComplexId)
        {
            return await _context.FitnessCenters
                .Where(fc => fc.SportComplexId == sportComplexId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymCenter>> GetGymCentersBySportComplexIdAsync(int sportComplexId)
        {
            return await _context.GymCenters
                .Where(gc => gc.SportComplexId == sportComplexId)
                .ToListAsync();
        }
    }
} 