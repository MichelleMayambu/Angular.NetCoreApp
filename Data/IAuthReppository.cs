namespace Angular.NetCoreApp.Data
{
    public interface IAuthReppository
    {
         Task<User> Register (User user, string password);

         Task<User> Login (string username , string password);

         Task<bool> UserExists (string username)
    }
}