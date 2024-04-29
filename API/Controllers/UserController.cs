
using DistributionAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DistributionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());

        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var dbUser = await _context.Users.FindAsync(user.user_id);
            if (dbUser == null)
            {
                return BadRequest("user not found");
            }
            dbUser.user_name = user.user_name;
            dbUser.user_fname = user.user_fname;
            dbUser.user_email = user.user_email;
            dbUser.user_fidelity= user.user_fidelity;
            dbUser.user_password=user.user_password;
            dbUser.user_dob = user.user_dob;
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());

        }
        [HttpDelete("{user_id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int user_id)
        {

            var dbUser = await _context.Users.FindAsync(user_id);
            if (dbUser == null)
            {
                return BadRequest("user not found");

            }
            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());


        }

    }
}
