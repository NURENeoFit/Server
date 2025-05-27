using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymTrainerRepository : GenericRepository<GymTrainer>, IGymTrainerRepository
    {
        public GymTrainerRepository(AppDbContext context) : base(context) { }
    }
} 