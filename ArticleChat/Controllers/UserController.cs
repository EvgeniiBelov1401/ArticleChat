using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using ArticleChat.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticleChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _userService.Register(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            _userService.Edit(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
