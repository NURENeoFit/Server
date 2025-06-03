using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGymTrainerRepository : IGenericRepository<GymTrainer>
    {
        Task<GymTrainer> CreateGymTrainerAsync(GymTrainer trainer);
        Task<GymTrainer> UpdateGymTrainerAsync(GymTrainer trainer);
        Task<bool> DeleteGymTrainerAsync(int trainerId);
        Task<GymTrainer> GetGymTrainerByIdAsync(int trainerId);
        Task<IEnumerable<GymTrainer>> GetAllGymTrainersAsync();
    }
} 