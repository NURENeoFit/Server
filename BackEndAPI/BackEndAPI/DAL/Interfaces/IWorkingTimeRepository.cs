using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IWorkingTimeRepository : IGenericRepository<WorkingTime>
    {
        Task<IEnumerable<WorkingTime>> GetAllSchedulesBySportComplexIdAsync(int sportComplexId);
        Task<WorkingTime> GetScheduleByDayAsync(int sportComplexId, string dayOfWeek);
        Task<bool> AddScheduleAsync(WorkingTime workingTime);
        Task<bool> IsScheduleExistsForDayAsync(int sportComplexId, string dayOfWeek);
    }
} 