using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UserRegistrationApi.Data;
using UserRegistrationApi.Models;

namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user == null)
            {
                return BadRequest(new { message = "Invalid user data." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(PostUser), new { id = user.Id }, user);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (for example, using a logging framework)
                Console.WriteLine(ex);

                // Return a 500 Internal Server Error response
                return StatusCode(500, new { message = "An error occurred while saving the user." });
            }
            catch (Exception ex)
            {
                // Log the exception (for example, using a logging framework)
                Console.WriteLine(ex);

                // Return a generic 500 Internal Server Error response
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}