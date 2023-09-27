using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SingUP(User user)
        {
            await _dbContext.User.AddAsync(user);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<bool> DeleteUser(int id)
        {
            var usuario = await _dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (usuario == null)
                return false;
            _dbContext.User.Remove(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> SingIN(string username, string password)
        {
            var usuario = await _dbContext.User
                .Where(x => x.Email == username && x.Password == password)
                .FirstOrDefaultAsync();


            if (usuario == null)
                return false;
            
           
            return true;
        }
    }
}
