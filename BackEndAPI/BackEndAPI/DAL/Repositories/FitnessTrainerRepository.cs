using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessTrainerRepository : GenericRepository<FitnessTrainer>, IFitnessTrainerRepository
    {
        public FitnessTrainerRepository(AppDbContext context) : base(context) { }
    }
} 