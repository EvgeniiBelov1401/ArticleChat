using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using ArticleChat.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace ArticleChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : ControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _userService.Register(user);
            Logger.Info($"User {user.Nickname} registered successfully.");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            _userService.Edit(user);
            Logger.Info($"User {user.Nickname} created successfully.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] User user)
        {
            _userService.Delete(id);
            Logger.Info($"User {user.Nickname} deleted successfully.");
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
