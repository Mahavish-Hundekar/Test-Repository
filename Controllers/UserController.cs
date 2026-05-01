<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.DTOs;
using MyApi.Models;
using MyApi.Repository;
using MyApi.Services;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly JwtService _jwt;

        public UserController(IUserRepository repo, JwtService jwt)
        {
            _repo = repo;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var exists = await _repo.GetByLoginNameAsync(dto.LoginName);
            if (exists != null)
                return BadRequest("User already exists");

            var user = new User
            {
                LoginName = dto.LoginName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FullName = dto.FullName,
                Email = dto.Email
            };

            await _repo.AddAsync(user);

            return Ok(await _repo.GetAllAsync());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _repo.GetByLoginNameAsync(dto.LoginName);

            if (user == null)
                return Unauthorized("Not registered");

            bool valid = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

            if (!valid)
                return Unauthorized("Invalid Password");

            var token = _jwt.GenerateToken(user);

            return Ok(new
            {
                user.LoginName,
                Token = token
            });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [Authorize]
        [HttpGet("{loginName}")]
        public async Task<IActionResult> GetByLoginName(string loginName)
        {
            var user = await _repo.GetByLoginNameAsync(loginName);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegisterDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.LoginName = dto.LoginName;
            user.FullName = dto.FullName;
            user.Email = dto.Email;

            await _repo.UpdateAsync(user);

            return Ok(user);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok("Deleted");
=======
﻿using GroceryApi.Data;
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
>>>>>>> 0ef7ab7f4ef1003900307c2bd54c6c0e7e18ca62
        }
    }
}