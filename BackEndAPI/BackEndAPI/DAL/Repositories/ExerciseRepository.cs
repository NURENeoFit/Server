using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext context) : base(context) { }
    }
} 