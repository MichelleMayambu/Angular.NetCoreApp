/*This repository class is responsible for querying our database via entity framework
                In here is where we inject our data context */

using System;
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

        public async Task<User> Register(User user, string password)
        {
           byte[] passwordHash, passwordSalt;
           CreatePasswordHash(password ,out passwordHash, out passwordSalt);

            user.PasswordHash= passwordHash;
            user.PasswordSalt=passwordSalt;

           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();

           return user;
        }

        //method to control storing of random Hash values 
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
           
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}