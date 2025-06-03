using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGroupTrainingBookingRepository : IGenericRepository<GroupTrainingBooking>
    {
        Task<IEnumerable<GroupTrainingBooking>> GetAllBookingsByUserIdAsync(int userId);
        Task<IEnumerable<GroupTrainingBooking>> GetAllBookingsByGroupScheduleIdAsync(int groupScheduleId);
        Task<IEnumerable<GroupTrainingBooking>> GetAllBookingsByGroupScheduleAndUserAsync(int groupScheduleId, int userId);
    }
} 