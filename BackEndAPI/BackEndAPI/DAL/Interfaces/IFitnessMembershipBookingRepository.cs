using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IFitnessMembershipBookingRepository : IGenericRepository<FitnessMembershipBooking>
    {
        Task<FitnessMembershipBooking> CreateFitnessMembershipBookingAsync(FitnessMembershipBooking booking);
        Task<FitnessMembershipBooking> UpdateFitnessMembershipBookingAsync(FitnessMembershipBooking booking);
        Task<bool> DeleteFitnessMembershipBookingAsync(int bookingId);
        Task<FitnessMembershipBooking> GetFitnessMembershipBookingByIdAsync(int bookingId);
        Task<IEnumerable<FitnessMembershipBooking>> GetAllFitnessMembershipBookingsAsync();
        Task<IEnumerable<FitnessMembershipBooking>> GetFitnessMembershipBookingsByUserIdAsync(int userId);
        Task<IEnumerable<FitnessMembershipBooking>> GetFitnessMembershipBookingsByFitnessMembershipIdAsync(int fitnessMembershipId);
    }
} 