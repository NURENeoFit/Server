using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessRoomRepository : GenericRepository<FitnessRoom>, IFitnessRoomRepository
    {
        public FitnessRoomRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<FitnessRoom>> GetAllFitnessRoomsByFitnessCenterIdAsync(int fitnessCenterId)
        {
            return await _context.FitnessRooms
                .Where(fr => fr.FitnessCenterId == fitnessCenterId)
                .ToListAsync();
        }
    }
} 