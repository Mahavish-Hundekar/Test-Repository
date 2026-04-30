using GroceryApi.Models;          // ✅ FIXED
using GroceryApi.Services;        // ✅ FIXED
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers   // ✅ FIXED
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtServices _jwtServices;

        public AuthController(JwtServices jwtServices)
        {
            _jwtServices = jwtServices;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Admin login
            if (login.UserName == "admin" && login.Password == "admin")
            {
                var token = _jwtServices.GenerateToken(login.UserName); // ✅ FIXED
                return Ok(new { token });
            }

            // Normal user
            if (login.UserName == "user1" && login.Password == "password")
            {
                var token = _jwtServices.GenerateToken(login.UserName); // ✅ FIXED
                return Ok(new { token });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}