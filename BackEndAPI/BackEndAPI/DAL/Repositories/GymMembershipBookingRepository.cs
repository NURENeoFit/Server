using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymMembershipBookingRepository : GenericRepository<GymMembershipBooking>, IGymMembershipBookingRepository
    {
        public GymMembershipBookingRepository(AppDbContext context) : base(context) { }

        public async Task<GymMembershipBooking> CreateGymMembershipBookingAsync(GymMembershipBooking booking)
        {
            await _context.GymMembershipBookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<GymMembershipBooking> UpdateGymMembershipBookingAsync(GymMembershipBooking booking)
        {
            var existingBooking = await _context.GymMembershipBookings
                .FirstOrDefaultAsync(b => b.GymMembershipBookingId == booking.GymMembershipBookingId);

            if (existingBooking == null)
                return null;

            _context.Entry(existingBooking).CurrentValues.SetValues(booking);
            await _context.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<bool> DeleteGymMembershipBookingAsync(int bookingId)
        {
            var booking = await _context.GymMembershipBookings
                .FirstOrDefaultAsync(b => b.GymMembershipBookingId == bookingId);

            if (booking == null)
                return false;

            _context.GymMembershipBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GymMembershipBooking> GetGymMembershipBookingByIdAsync(int bookingId)
        {
            return await _context.GymMembershipBookings
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.Membership)
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.GymCenter)
                .FirstOrDefaultAsync(b => b.GymMembershipBookingId == bookingId);
        }

        public async Task<IEnumerable<GymMembershipBooking>> GetAllGymMembershipBookingsAsync()
        {
            return await _context.GymMembershipBookings
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.Membership)
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.GymCenter)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymMembershipBooking>> GetGymMembershipBookingsByUserIdAsync(int userId)
        {
            return await _context.GymMembershipBookings
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.Membership)
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.GymCenter)
                .Where(b => b.GymMembership.Membership.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymMembershipBooking>> GetGymMembershipBookingsByGymMembershipIdAsync(int gymMembershipId)
        {
            return await _context.GymMembershipBookings
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.Membership)
                .Include(b => b.GymMembership)
                    .ThenInclude(gm => gm.GymCenter)
                .Where(b => b.GymMembershipBookingId == gymMembershipId)
                .ToListAsync();
        }
    }
} 