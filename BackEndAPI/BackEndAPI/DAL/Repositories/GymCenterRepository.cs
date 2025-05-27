using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymCenterRepository : GenericRepository<GymCenter>, IGymCenterRepository
    {
        public GymCenterRepository(AppDbContext context) : base(context) { }
    }
} 