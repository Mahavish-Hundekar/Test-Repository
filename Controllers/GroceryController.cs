using GroceryApi.Data;
using GroceryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;                    // ✅ ADD THIS

namespace GroceryApi.Controllers     // ✅ FIXED
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroceryController(AppDbContext context)
        {
            _context = context;
        }

        // Add Grocery
        [HttpPost]
        public IActionResult AddGrocery(Grocery grocery)
        {
            _context.Groceries.Add(grocery);
            _context.SaveChanges();

            return Ok(grocery);
        }

        // Get by User & Date
        [HttpGet]
        public IActionResult Get(int userId, DateTime date)
        {
            var data = _context.Groceries
                .Where(x => x.UserId == userId && x.Date.Date == date.Date)
                .ToList();

            return Ok(data);
        }

        // Next 15 Days
        [HttpGet("next15days")]
        public IActionResult GetNext15Days(int userId)
        {
            var start = DateTime.Today;
            var end = start.AddDays(15);

            var data = _context.Groceries
                .Where(x => x.UserId == userId &&
                            x.Date >= start &&
                            x.Date <= end)
                .ToList();

            return Ok(data);
        }
    }
}