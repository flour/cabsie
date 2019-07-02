using Cabsie.API.Models;
using System.Threading.Tasks;

namespace Cabsie.API.Services
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<bool> HasUniqEmailAsync(string email);
        Task<bool> HasUniqueUsernameAsync(string username);
    }

    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context) { }

        public async Task<bool> HasUniqEmailAsync(string email)
         => (await GetItemAsync(u => u.Email == email)) == null;

        public async Task<bool> HasUniqueUsernameAsync(string username)
         => (await GetItemAsync(u => u.Username == username)) == null;
    }
}
