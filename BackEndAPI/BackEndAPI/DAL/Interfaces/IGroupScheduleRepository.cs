using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGroupScheduleRepository : IGenericRepository<GroupSchedule>
    {
        Task<IEnumerable<GroupSchedule>> GetAllSchedulesByGroupTrainingIdAsync(int groupTrainingId);
        Task<IEnumerable<GroupSchedule>> GetAllSchedulesByFitnessTrainerIdAsync(int fitnessTrainerId);
        Task<IEnumerable<GroupSchedule>> GetAllSchedulesByGroupTrainingAndTrainerAsync(int groupTrainingId, int fitnessTrainerId);
    }
} 