using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymTrainerMembershipBookingRepository : GenericRepository<GymTrainerMembershipBooking>
    {
        public GymTrainerMembershipBookingRepository(AppDbContext context) : base(context) { }

        public async Task<GymTrainerMembershipBooking> CreateGymTrainerMembershipBookingAsync(GymTrainerMembershipBooking booking)
        {
            await _context.GymTrainerMembershipBookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<GymTrainerMembershipBooking> UpdateGymTrainerMembershipBookingAsync(GymTrainerMembershipBooking booking)
        {
            var existingBooking = await _context.GymTrainerMembershipBookings
                .FirstOrDefaultAsync(b => b.GymTrainerMembershipBookingId == booking.GymTrainerMembershipBookingId);

            if (existingBooking == null)
                return null;

            _context.Entry(existingBooking).CurrentValues.SetValues(booking);
            await _context.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<bool> DeleteGymTrainerMembershipBookingAsync(int bookingId)
        {
            var booking = await _context.GymTrainerMembershipBookings
                .FirstOrDefaultAsync(b => b.GymTrainerMembershipBookingId == bookingId);

            if (booking == null)
                return false;

            _context.GymTrainerMembershipBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GymTrainerMembershipBooking> GetGymTrainerMembershipBookingByIdAsync(int bookingId)
        {
            return await _context.GymTrainerMembershipBookings
                .Include(b => b.GymTrainerMembership)
                    .ThenInclude(gtm => gtm.Membership)
                .Include(b => b.GymTrainerMembership)
                    .ThenInclude(gtm => gtm.GymTrainer)
                .FirstOrDefaultAsync(b => b.GymTrainerMembershipBookingId == bookingId);
        }

        public async Task<IEnumerable<GymTrainerMembershipBooking>> GetAllGymTrainerMembershipBookingsAsync()
        {
            return await _context.GymTrainerMembershipBookings
                .Include(b => b.GymTrainerMembership)
                    .ThenInclude(gtm => gtm.Membership)
                .Include(b => b.GymTrainerMembership)
                    .ThenInclude(gtm => gtm.GymTrainer)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymTrainerMembershipBooking>> GetGymTrainerMembershipBookingsByUserIdAsync(int userId)
        {
            return await _context.GymTrainerMembershipBookings
                .Include(b => b.GymTrainerMembership)
                    .ThenInclude(gtm => gtm.Membership)
                .Include(b => b.GymTrainerMembership)
                    .ThenInclude(gtm => gtm.GymTrainer)
                .Where(b => b.GymTrainerMembership.Membership.UserId == userId)
                .ToListAsync();
        }

        //public async Task<IEnumerable<GymTrainerMembershipBooking>> GetGymTrainerMembershipBookingsByGymTrainerMembershipIdAsync(int gymTrainerMembershipId)
        //{
        //    return await _context.GymTrainerMembershipBookings
        //        .Include(b => b.GymTrainerMembership)
        //            .ThenInclude(gtm => gtm.Membership)
        //        .Include(b => b.GymTrainerMembership)
        //            .ThenInclude(gtm => gtm.GymTrainer)
        //        .Where(b => b.GymTrainerMembershipId == gymTrainerMembershipId)
        //        .OrderByDescending(b => b.BookingDate)
        //        .ToListAsync();
        //}
    }
} 