using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class FitnessMembershipRepository : GenericRepository<FitnessMembership>, IFitnessMembershipRepository
    {
        public FitnessMembershipRepository(AppDbContext context) : base(context) { }

        public async Task<FitnessMembership> CreateFitnessMembershipAsync(FitnessMembership membership)
        {
            // Сначала создаем базовое членство
            var baseMembership = new Membership
            {
                UserId = membership.UserId,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate,
                MembershipPrice = membership.MembershipPrice
            };

            _context.Memberships.Add(baseMembership);
            await _context.SaveChangesAsync();

            // Затем создаем фитнес-членство с привязкой к базовому членству
            membership.MembershipId = baseMembership.MembershipId;
            await _context.FitnessMemberships.AddAsync(membership);
            await _context.SaveChangesAsync();

            return membership;
        }

        public async Task<FitnessMembership> UpdateFitnessMembershipAsync(FitnessMembership membership)
        {
            var existingMembership = await _context.FitnessMemberships
                .Include(fm => fm.Membership)
                .FirstOrDefaultAsync(fm => fm.MembershipId == membership.MembershipId);

            if (existingMembership == null)
                return null;

            // Обновляем базовые данные членства
            existingMembership.Membership.StartDate = membership.StartDate;
            existingMembership.Membership.EndDate = membership.EndDate;
            existingMembership.Membership.MembershipPrice = membership.MembershipPrice;

            // Обновляем специфичные данные фитнес-членства
            existingMembership.FitnessCenterId = membership.FitnessCenterId;

            await _context.SaveChangesAsync();
            return existingMembership;
        }

        public async Task<bool> DeleteFitnessMembershipAsync(int membershipId)
        {
            var membership = await _context.FitnessMemberships
                .Include(fm => fm.Membership)
                .FirstOrDefaultAsync(fm => fm.MembershipId == membershipId);

            if (membership == null)
                return false;

            _context.FitnessMemberships.Remove(membership);
            _context.Memberships.Remove(membership.Membership);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FitnessMembership> GetFitnessMembershipByIdAsync(int membershipId)
        {
            return await _context.FitnessMemberships
                .Include(fm => fm.Membership)
                .Include(fm => fm.FitnessCenter)
                .FirstOrDefaultAsync(fm => fm.MembershipId == membershipId);
        }

        public async Task<IEnumerable<FitnessMembership>> GetAllFitnessMembershipsAsync()
        {
            return await _context.FitnessMemberships
                .Include(fm => fm.Membership)
                .Include(fm => fm.FitnessCenter)
                .ToListAsync();
        }

        public async Task<IEnumerable<FitnessMembership>> GetFitnessMembershipsByUserIdAsync(int userId)
        {
            return await _context.FitnessMemberships
                .Include(fm => fm.Membership)
                .Include(fm => fm.FitnessCenter)
                .Where(fm => fm.Membership.UserId == userId)
                .OrderByDescending(fm => fm.Membership.StartDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<FitnessMembership>> GetFitnessMembershipsByFitnessCenterIdAsync(int fitnessCenterId)
        {
            return await _context.FitnessMemberships
                .Include(fm => fm.Membership)
                .Where(fm => fm.FitnessCenterId == fitnessCenterId)
                .OrderByDescending(fm => fm.Membership.StartDate)
                .ToListAsync();
        }
    }
} 