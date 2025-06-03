using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class TrainerSpecializationRepository : GenericRepository<TrainerSpecialization>, ITrainerSpecializationRepository
    {
        public TrainerSpecializationRepository(AppDbContext context) : base(context) { }
    }
} 