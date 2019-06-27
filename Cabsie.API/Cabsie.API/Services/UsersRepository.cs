using Cabsie.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cabsie.API.Services
{
    public interface IUsersRepository : IGenericRepository<User>
    {

    }

    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;
        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateItem(User item)
        {
            _context.Add(item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var user = await GetItemAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task<User> GetItemAsync(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetItemsAsync(int page = 1, int perPage = 10)
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateItem(User item)
        {
            _context.Users.Update(item);
        }
    }
}
