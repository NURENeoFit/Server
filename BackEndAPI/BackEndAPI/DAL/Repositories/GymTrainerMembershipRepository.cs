using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class GymTrainerMembershipRepository : GenericRepository<GymTrainerMembership>, IGymTrainerMembershipRepository
    {
        public GymTrainerMembershipRepository(AppDbContext context) : base(context) { }

        public async Task<GymTrainerMembership> CreateGymTrainerMembershipAsync(GymTrainerMembership membership)
        {
            // Сначала создаем базовое членство
            var baseMembership = new Membership
            {
                UserId = membership.UserId,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate,
                Status = membership.Status,
                Price = membership.Price
            };

            _context.Memberships.Add(baseMembership);
            await _context.SaveChangesAsync();

            // Затем создаем членство с тренером с привязкой к базовому членству
            membership.MembershipId = baseMembership.MembershipId;
            await _context.GymTrainerMemberships.AddAsync(membership);
            await _context.SaveChangesAsync();

            return membership;
        }

        public async Task<GymTrainerMembership> UpdateGymTrainerMembershipAsync(GymTrainerMembership membership)
        {
            var existingMembership = await _context.GymTrainerMemberships
                .Include(gtm => gtm.Membership)
                .FirstOrDefaultAsync(gtm => gtm.MembershipId == membership.MembershipId);

            if (existingMembership == null)
                return null;

            // Обновляем базовые данные членства
            existingMembership.Membership.StartDate = membership.StartDate;
            existingMembership.Membership.EndDate = membership.EndDate;
            existingMembership.Membership.Status = membership.Status;
            existingMembership.Membership.Price = membership.Price;

            // Обновляем специфичные данные членства с тренером
            existingMembership.GymTrainerId = membership.GymTrainerId;
            existingMembership.WorkoutProgramIds = membership.WorkoutProgramIds;

            await _context.SaveChangesAsync();
            return existingMembership;
        }

        public async Task<bool> DeleteGymTrainerMembershipAsync(int membershipId)
        {
            var membership = await _context.GymTrainerMemberships
                .Include(gtm => gtm.Membership)
                .FirstOrDefaultAsync(gtm => gtm.MembershipId == membershipId);

            if (membership == null)
                return false;

            _context.GymTrainerMemberships.Remove(membership);
            _context.Memberships.Remove(membership.Membership);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GymTrainerMembership> GetGymTrainerMembershipByIdAsync(int membershipId)
        {
            return await _context.GymTrainerMemberships
                .Include(gtm => gtm.Membership)
                .Include(gtm => gtm.GymTrainer)
                .FirstOrDefaultAsync(gtm => gtm.MembershipId == membershipId);
        }

        public async Task<IEnumerable<GymTrainerMembership>> GetAllGymTrainerMembershipsAsync()
        {
            return await _context.GymTrainerMemberships
                .Include(gtm => gtm.Membership)
                .Include(gtm => gtm.GymTrainer)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymTrainerMembership>> GetGymTrainerMembershipsByUserIdAsync(int userId)
        {
            return await _context.GymTrainerMemberships
                .Include(gtm => gtm.Membership)
                .Include(gtm => gtm.GymTrainer)
                .Where(gtm => gtm.Membership.UserId == userId)
                .OrderByDescending(gtm => gtm.Membership.StartDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymTrainerMembership>> GetGymTrainerMembershipsByTrainerIdAsync(int trainerId)
        {
            return await _context.GymTrainerMemberships
                .Include(gtm => gtm.Membership)
                .Where(gtm => gtm.GymTrainerId == trainerId)
                .OrderByDescending(gtm => gtm.Membership.StartDate)
                .ToListAsync();
        }
    }
} 