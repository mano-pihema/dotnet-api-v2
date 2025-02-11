using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _userRepo;

        public UserController(IUsersRepository usersRepo)
        {
            _userRepo = usersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepo.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser([FromRoute] int id)
        {
            var user = await _userRepo.GetUserAsync(id);
            return Ok(user);
        }
    }
}
