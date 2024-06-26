using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var res = op.Login(user);
            if (res != "")
            {
                return Ok(res);
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

        [HttpPost]
        [Route("api/Account/GetInfo")]
        public IActionResult GetInfo([FromBody] LoginInfo info)
        {
            UserOperations op = new UserOperations();
            var res = op.Login(info);
            if (res != "")
            {
                var user = op.GetInfo(info.Email);
                return Ok(JsonConvert.SerializeObject(user));
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("api/Account/UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            UserOperations op = new UserOperations();
            op.Update(user);
            return Ok();
        }
    }
}
