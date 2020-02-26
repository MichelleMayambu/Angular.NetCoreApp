using System.Threading.Tasks;
using Angular.NetCoreApp.Data;
using Angular.NetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Angular.NetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        //inject AuthInterface
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo )
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username , string password)
        {
            //validate request

            username =username.ToLower();

            if(await _repo.UserExists(username))
                return BadRequest("username is already exists");

            var userToCreate = new User
            {
                UserName = username
            };

            var createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201)
        }
        
        

    }
}