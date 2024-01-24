using APIDawerDaway.Models;
using APIDawerDaway.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDawerDaway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly AppDbContext _context;

        public UserController(ILogger<UserController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.Id == id)
                    //.Include(u => u.FeedBacks) // Include related entities if needed
                    //.Include(u => u.UserProducts) // Include related entities if needed
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(); // User with the specified ID not found
                }

                return Ok(user);
            }
            catch (System.Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name ="GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<User>> RegisterUser(RegisterUserVM registerUserVM)
        {
            try
            {
                // You can add additional validation here if needed
                if (string.IsNullOrEmpty(registerUserVM.UserName) || string.IsNullOrEmpty(registerUserVM.Password))
                {
                    return BadRequest("UserName and Password are required");
                }

                // Create a new User object and assign values from the ViewModel
                var newUser = new User
                {
                    UserName = registerUserVM.UserName,
                    Password = registerUserVM.Password,
                    PhoneNumber = registerUserVM.PhoneNumber,
                    feedbacks = new List<FeedBack>(),
                    userproducts = new List<UserProduct>(),

                    // Assign other default values if needed
                };

                // Add the new user to the database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                var response = new
                {
                    password = registerUserVM.Password,
                    phoneNumber = registerUserVM.PhoneNumber,
                    userName = registerUserVM.UserName,
                    userId = newUser.Id,
                    status = "200",
                };
                //Console.WriteLine(nameof(GetUserById), new { id = newUser.Id }, newUser);
                //return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }

        // You might have other methods in the UserController for fetching users, etc.

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
}
