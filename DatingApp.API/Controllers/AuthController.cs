using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            var userName = userForRegisterDto.UserName.ToLower();

            if(await _repo.UserExists(userName))
                return BadRequest("UserName already ecists");
                
            var userToCreate = new User(){
                UserName = userName
            };

            var createduser = _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }


    }
}