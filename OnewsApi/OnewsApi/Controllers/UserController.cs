using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnewsApi.Models;
using OnewsApi.Operations;

namespace OnewsApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("api/Account/Login")]
        public IActionResult Login([FromBody] LoginInfo user)
        {
            UserOperations op = new UserOperations();
            if (op.Login(user))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("api/Account/Register")]
        public IActionResult Register([FromBody] User user)
        {
            UserOperations op = new UserOperations();
            if (op.Register(user))
            {
                return Ok("Регистрация успешна");
            }
            else
            {
                return Unauthorized("Введенный email уже занят");
            }
        }
    }
}
