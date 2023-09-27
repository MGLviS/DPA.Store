using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("SinUP")]
        public async Task<IActionResult> SingUP(User user)
        {
            var result = await _userRepository.SingUP(user);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getU")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete("DeleteU")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("SingIN")]
        public async Task<IActionResult> SingIN(string username, string password)
        {
            var result = await _userRepository.SingIN(username, password);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
