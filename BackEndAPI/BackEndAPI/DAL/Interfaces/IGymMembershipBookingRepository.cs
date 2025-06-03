using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGymMembershipBookingRepository : IGenericRepository<GymMembershipBooking>
    {
        Task<GymMembershipBooking> CreateGymMembershipBookingAsync(GymMembershipBooking booking);
        Task<GymMembershipBooking> UpdateGymMembershipBookingAsync(GymMembershipBooking booking);
        Task<bool> DeleteGymMembershipBookingAsync(int bookingId);
        Task<GymMembershipBooking> GetGymMembershipBookingByIdAsync(int bookingId);
        Task<IEnumerable<GymMembershipBooking>> GetAllGymMembershipBookingsAsync();
        Task<IEnumerable<GymMembershipBooking>> GetGymMembershipBookingsByUserIdAsync(int userId);
        Task<IEnumerable<GymMembershipBooking>> GetGymMembershipBookingsByGymMembershipIdAsync(int gymMembershipId);
    }
} 