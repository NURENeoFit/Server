using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IFitnessTrainerRepository : IGenericRepository<FitnessTrainer>
    {
        Task<FitnessTrainer> CreateFitnessTrainerAsync(FitnessTrainer trainer);
        Task<FitnessTrainer> UpdateFitnessTrainerAsync(FitnessTrainer trainer);
        Task<bool> DeleteFitnessTrainerAsync(int trainerId);
        Task<FitnessTrainer> GetFitnessTrainerByIdAsync(int trainerId);
        Task<IEnumerable<FitnessTrainer>> GetAllFitnessTrainersAsync();
        Task<IEnumerable<FitnessTrainer>> GetFitnessTrainersBySpecializationAsync(int specializationId);
    }
} 