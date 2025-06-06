using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymMembershipRepository : GenericRepository<GymMembership>, IGymMembershipRepository
    {
        public GymMembershipRepository(AppDbContext context) : base(context) { }

        public async Task<GymMembership> CreateGymMembershipAsync(GymMembership membership)
        {
            // Сначала создаем базовое членство
            var baseMembership = new Membership
            {
                MembershipPrice = membership.MembershipPrice,
                MembershipName = membership.MembershipName,
                MembershipDescription = membership.MembershipDescription,
            };

            _context.Memberships.Add(baseMembership);
            await _context.SaveChangesAsync();

            // Затем создаем спорт-членство с привязкой к базовому членству
            membership.MembershipId = baseMembership.MembershipId;
            await _context.GymMemberships.AddAsync(membership);
            await _context.SaveChangesAsync();

            return membership;
        }

        public async Task<GymMembership> UpdateGymMembershipAsync(GymMembership membership)
        {
            var existingMembership = await _context.GymMemberships
                .Include(gm => gm.Membership)
                .FirstOrDefaultAsync(gm => gm.MembershipId == membership.MembershipId);

            if (existingMembership == null)
                return null;

            // Обновляем базовые данные членства
            existingMembership.Membership.StartDate = membership.StartDate;
            existingMembership.Membership.EndDate = membership.EndDate;

            // Обновляем специфичные данные спорт-членства
            existingMembership.GymCenterId = membership.GymCenterId;
            existingMembership.GymMembershipBookings = membership.GymMembershipBookings;

            await _context.SaveChangesAsync();
            return existingMembership;
        }

        public async Task<bool> DeleteGymMembershipAsync(int membershipId)
        {
            var membership = await _context.GymMemberships
                .Include(gm => gm.Membership)
                .FirstOrDefaultAsync(gm => gm.MembershipId == membershipId);

            if (membership == null)
                return false;

            _context.GymMemberships.Remove(membership);
            _context.Memberships.Remove(membership.Membership);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GymMembership> GetGymMembershipByIdAsync(int membershipId)
        {
            return await _context.GymMemberships
                .Include(gm => gm.Membership)
                .Include(gm => gm.GymCenter)
                .FirstOrDefaultAsync(gm => gm.MembershipId == membershipId);
        }

        public async Task<IEnumerable<GymMembership>> GetAllGymMembershipsAsync()
        {
            return await _context.GymMemberships
                .Include(gm => gm.Membership)
                .Include(gm => gm.GymCenter)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymMembership>> GetGymMembershipsByGymCenterIdAsync(int gymCenterId)
        {
            return await _context.GymMemberships
                .Include(gm => gm.Membership)
                .Where(gm => gm.GymCenterId == gymCenterId)
                .OrderByDescending(gm => gm.Membership.StartDate)
                .ToListAsync();
        }
    }
} 