using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEndAPI.Entities;
using BackEndAPI.DAL.Interfaces;

namespace BackEndAPI.DAL.Repositories
{
    public class PersonalUserDataRepository : GenericRepository<PersonalUserData>, IPersonalUserDataRepository
    {
        public PersonalUserDataRepository(AppDbContext context) : base(context) { }

        public async Task<PersonalUserData> GetPersonalUserDataByUserIdAsync(int userId)
        {
            return await _context.PersonalUserData
                .FirstOrDefaultAsync(pud => pud.UserId == userId);
        }
    }
} 