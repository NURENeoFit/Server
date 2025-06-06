using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessMembershipBookingRepository : GenericRepository<FitnessMembershipBooking>, IFitnessMembershipBookingRepository
    {
        public FitnessMembershipBookingRepository(AppDbContext context) : base(context) { }

        public async Task<FitnessMembershipBooking> CreateFitnessMembershipBookingAsync(FitnessMembershipBooking booking)
        {
            await _context.FitnessMembershipBookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<FitnessMembershipBooking> UpdateFitnessMembershipBookingAsync(FitnessMembershipBooking booking)
        {
            var existingBooking = await _context.FitnessMembershipBookings
                .FirstOrDefaultAsync(b => b.FitnessMembershipBookingId == booking.FitnessMembershipBookingId);

            if (existingBooking == null)
                return null;

            _context.Entry(existingBooking).CurrentValues.SetValues(booking);
            await _context.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<bool> DeleteFitnessMembershipBookingAsync(int bookingId)
        {
            var booking = await _context.FitnessMembershipBookings
                .FirstOrDefaultAsync(b => b.FitnessMembershipBookingId == bookingId);

            if (booking == null)
                return false;

            _context.FitnessMembershipBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FitnessMembershipBooking> GetFitnessMembershipBookingByIdAsync(int bookingId)
        {
            return await _context.FitnessMembershipBookings
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.Membership)
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.FitnessCenter)
                .FirstOrDefaultAsync(b => b.FitnessMembershipBookingId == bookingId);
        }

        public async Task<IEnumerable<FitnessMembershipBooking>> GetAllFitnessMembershipBookingsAsync()
        {
            return await _context.FitnessMembershipBookings
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.Membership)
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.FitnessCenter)
                .ToListAsync();
        }

        public async Task<IEnumerable<FitnessMembershipBooking>> GetFitnessMembershipBookingsByUserIdAsync(int userId)
        {
            return await _context.FitnessMembershipBookings
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.Membership)
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.FitnessCenter)
                .Where(b => b.FitnessMembership.Membership.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<FitnessMembershipBooking>> GetFitnessMembershipBookingsByFitnessMembershipIdAsync(int fitnessMembershipId)
        {
            return await _context.FitnessMembershipBookings
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.Membership)
                .Include(b => b.FitnessMembership)
                    .ThenInclude(fm => fm.FitnessCenter)
                .Where(b => b.MembershipId == fitnessMembershipId)
                .ToListAsync();
        }
    }
} 