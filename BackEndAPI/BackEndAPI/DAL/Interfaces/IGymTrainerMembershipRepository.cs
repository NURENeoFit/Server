using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IGymTrainerMembershipRepository : IGenericRepository<GymTrainerMembership>
    {
        Task<GymTrainerMembership> CreateGymTrainerMembershipAsync(GymTrainerMembership membership);
        Task<GymTrainerMembership> UpdateGymTrainerMembershipAsync(GymTrainerMembership membership);
        Task<bool> DeleteGymTrainerMembershipAsync(int membershipId);
        Task<GymTrainerMembership> GetGymTrainerMembershipByIdAsync(int membershipId);
        Task<IEnumerable<GymTrainerMembership>> GetAllGymTrainerMembershipsAsync();
        Task<IEnumerable<GymTrainerMembership>> GetGymTrainerMembershipsByTrainerIdAsync(int trainerId);
    }
} 