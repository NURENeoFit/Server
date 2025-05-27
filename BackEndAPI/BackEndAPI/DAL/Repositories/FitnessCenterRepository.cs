using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessCenterRepository : GenericRepository<FitnessCenter>, IFitnessCenterRepository
    {
        public FitnessCenterRepository(AppDbContext context) : base(context) { }
    }
} 