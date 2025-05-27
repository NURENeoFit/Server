using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class UserMealRepository : GenericRepository<UserMeal>, IUserMealRepository
    {
        public UserMealRepository(AppDbContext context) : base(context) { }
    }
} 