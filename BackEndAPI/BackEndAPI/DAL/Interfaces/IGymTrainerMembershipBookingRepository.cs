using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGymTrainerMembershipBookingRepository : IGenericRepository<GymTrainerMembershipBooking>
    {
        Task<GymTrainerMembershipBooking> CreateGymTrainerMembershipBookingAsync(GymTrainerMembershipBooking booking);
        Task<GymTrainerMembershipBooking> UpdateGymTrainerMembershipBookingAsync(GymTrainerMembershipBooking booking);
        Task<bool> DeleteGymTrainerMembershipBookingAsync(int bookingId);
        Task<GymTrainerMembershipBooking> GetGymTrainerMembershipBookingByIdAsync(int bookingId);
        Task<IEnumerable<GymTrainerMembershipBooking>> GetAllGymTrainerMembershipBookingsAsync();
        Task<IEnumerable<GymTrainerMembershipBooking>> GetGymTrainerMembershipBookingsByUserIdAsync(int userId);
        Task<IEnumerable<GymTrainerMembershipBooking>> GetGymTrainerMembershipBookingsByGymTrainerMembershipIdAsync(int gymTrainerMembershipId);
    }
} 