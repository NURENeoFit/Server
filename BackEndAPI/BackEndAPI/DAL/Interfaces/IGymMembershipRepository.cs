using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGymMembershipRepository : IGenericRepository<GymMembership>
    {
        Task<GymMembership> CreateGymMembershipAsync(GymMembership membership);
        Task<GymMembership> UpdateGymMembershipAsync(GymMembership membership);
        Task<bool> DeleteGymMembershipAsync(int membershipId);
        Task<GymMembership> GetGymMembershipByIdAsync(int membershipId);
        Task<IEnumerable<GymMembership>> GetAllGymMembershipsAsync();
        Task<IEnumerable<GymMembership>> GetGymMembershipsByUserIdAsync(int userId);
        Task<IEnumerable<GymMembership>> GetGymMembershipsByGymCenterIdAsync(int gymCenterId);
    }
} 