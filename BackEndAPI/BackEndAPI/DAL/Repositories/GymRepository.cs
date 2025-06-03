using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymRepository : GenericRepository<Gym>, IGymRepository
    {
        public GymRepository(AppDbContext context) : base(context) { }
    }
} 