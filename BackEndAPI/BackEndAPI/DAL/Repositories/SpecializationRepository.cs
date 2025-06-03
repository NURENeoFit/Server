using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Specialization>> GetSpecializationsByTrainerIdAsync(int trainerId)
        {
            var trainer = await _context.FitnessTrainers
                .Include(ft => ft.Specializations)
                .FirstOrDefaultAsync(ft => ft.TrainerId == trainerId);

            return trainer?.Specializations ?? new List<Specialization>();
        }
    }
} 