using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGroupTrainingRepository : IGenericRepository<GroupTraining>
    {
        Task<IEnumerable<GroupTraining>> GetAllGroupTrainingsByFitnessCenterIdAsync(int fitnessCenterId);
        Task<IEnumerable<GroupTraining>> GetAllGroupTrainingsBySpecializationIdAsync(int specializationId);
        Task<IEnumerable<GroupTraining>> GetAllGroupTrainingsByFitnessCenterAndSpecializationAsync(int fitnessCenterId, int specializationId);
    }
} 