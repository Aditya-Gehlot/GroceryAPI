using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Grocery.common.Model;
using Grocery.services.Interfaces;
using Grocery.services.Classes;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            IActionResult response = Unauthorized();
            var authenticatedUser = _loginService.AuthenticationUser(user);
            if (authenticatedUser != null)
            {
                var token = _loginService.GenerateToken(authenticatedUser);
                response = Ok(new { token = token });
            }
            return response;
        }
    }
}
