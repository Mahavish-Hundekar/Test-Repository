using GroceryApi.Data;
using GroceryApi.Models;
using Microsoft.AspNetCore.Authorization;   // ✅ ADD
using Microsoft.AspNetCore.Mvc;
using System.Linq;                          // ✅ ADD

namespace GroceryApi.Controllers
{
    [Authorize]   // 🔐 PROTECT CONTROLLER
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Add User
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user == null)
                return BadRequest("Invalid data");

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        // ✅ Get All Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}