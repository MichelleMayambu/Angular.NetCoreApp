/*This repository class is responsible for querying our database via entity framework
                In here is where we inject our data context */

using System.Threading.Tasks;
using Angular.NetCoreApp.Models;

namespace Angular.NetCoreApp.Data
{
    public class AuthRepository : IAuthRepository
    {
        //inject dataContext here
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}