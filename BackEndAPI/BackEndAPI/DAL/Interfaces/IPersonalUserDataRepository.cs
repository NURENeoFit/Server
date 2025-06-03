using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndAPI.Entities;

namespace BackEndAPI.DAL.Interfaces
{
    public interface IPersonalUserDataRepository : IGenericRepository<PersonalUserData>
    {
        Task<PersonalUserData> GetPersonalUserDataByUserIdAsync(int userId);
    }
} 