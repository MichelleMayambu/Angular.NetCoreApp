/*This repository class is responsible for querying our database via entity framework
                In here is where we inject our data context */

using System;
using System.Threading.Tasks;
using Angular.NetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User> Login(string username, string password)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
           
           if (user == null)
           return null;

           if(VerifyPasswordHash(password, user.PasswordHash,user.PasswordSalt))
           return null;
          

           return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
             {  
                var computedHash =hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                 for (int i = 0; i < computedHash.Length; i++)
                 {
                    if(computedHash[i] != passwordHash[i]) return false;
                 }
            }
                return true;
            
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