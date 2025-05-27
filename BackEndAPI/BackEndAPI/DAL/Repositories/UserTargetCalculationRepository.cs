using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class UserTargetCalculationRepository : GenericRepository<UserTargetCalculation>, IUserTargetCalculationRepository
    {
        public UserTargetCalculationRepository(AppDbContext context) : base(context) { }
    }
} 