using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class UserExerciseLogRepository : GenericRepository<UserExerciseLog>, IUserExerciseLogRepository
    {
        public UserExerciseLogRepository(AppDbContext context) : base(context) { }
    }
} 