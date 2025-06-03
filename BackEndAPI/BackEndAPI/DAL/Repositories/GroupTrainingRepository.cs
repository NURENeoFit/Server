using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GroupTrainingRepository : GenericRepository<GroupTraining>, IGroupTrainingRepository
    {
        public GroupTrainingRepository(AppDbContext context) : base(context) { }


        public async Task<IEnumerable<GroupTraining>> GetAllGroupTrainingsByFitnessCenterIdAsync(int fitnessCenterId)
        {
            return await _context.GroupTrainings
                .Include(gt => gt.Specialization)
                .Include(gt => gt.FitnessRoom)
                .Where(gt => gt.FitnessRoom.FitnessCenterId == fitnessCenterId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupTraining>> GetAllGroupTrainingsBySpecializationIdAsync(int specializationId)
        {
            return await _context.GroupTrainings
                .Include(gt => gt.Specialization)
                .Include(gt => gt.FitnessRoom)
                .Where(gt => gt.SpecializationId == specializationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GroupTraining>> GetAllGroupTrainingsByFitnessCenterAndSpecializationAsync(int fitnessCenterId, int specializationId)
        {
            return await _context.GroupTrainings
                .Include(gt => gt.Specialization)
                .Include(gt => gt.FitnessRoom)
                .Where(gt => gt.FitnessRoom.FitnessCenterId == fitnessCenterId && gt.SpecializationId == specializationId)
                .ToListAsync();
        }
    }
} 