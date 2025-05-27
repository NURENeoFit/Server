using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class WorkingTimeRepository : GenericRepository<WorkingTime>, IWorkingTimeRepository
    {
        public WorkingTimeRepository(AppDbContext context) : base(context) { }
    }
} 