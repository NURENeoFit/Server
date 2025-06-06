using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IFitnessMembershipRepository : IGenericRepository<FitnessMembership>
    {
        Task<FitnessMembership> CreateFitnessMembershipAsync(FitnessMembership membership);
        Task<FitnessMembership> UpdateFitnessMembershipAsync(FitnessMembership membership);
        Task<bool> DeleteFitnessMembershipAsync(int membershipId);
        Task<FitnessMembership> GetFitnessMembershipByIdAsync(int membershipId);
        Task<IEnumerable<FitnessMembership>> GetAllFitnessMembershipsAsync();
        Task<IEnumerable<FitnessMembership>> GetFitnessMembershipsByFitnessCenterIdAsync(int fitnessCenterId);
    }
} 