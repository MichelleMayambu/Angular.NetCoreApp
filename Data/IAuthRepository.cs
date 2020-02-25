using System.Threading.Tasks;
using Angular.NetCoreApp.Models;


namespace Angular.NetCoreApp.Data
{
    public interface IAuthRepository
    {
         Task<User> Register (User user, string password);

         Task<User> Login (string username , string password);

         Task<bool> UserExists (string username);
    }
}