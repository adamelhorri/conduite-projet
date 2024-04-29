
using DistributionAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DistributionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdmins()
        {
            return Ok(await _context.Admins.ToListAsync());

        }
        [HttpPost]
        public async Task<ActionResult<List<Admin>>> PostAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return Ok(await _context.Admins.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Admin>>> UpdateAdmin(Admin admin)
        {
            var dbAdmin = await _context.Admins.FindAsync(admin.admin_id);
            if (dbAdmin == null)
            {
                return BadRequest("admin not found");
            }
            dbAdmin.admin_name = admin.admin_name;
            dbAdmin.admin_fname = admin.admin_fname;
            dbAdmin.admin_email = admin.admin_email;
         
            dbAdmin.admin_password = admin.admin_password;
         
            await _context.SaveChangesAsync();
            return Ok(await _context.Admins.ToListAsync());

        }
        [HttpDelete("{admin_id}")]
        public async Task<ActionResult<List<Admin>>> DeleteAdmin(int admin_id)
        {

            var dbAdmin = await _context.Admins.FindAsync(admin_id);
            if (dbAdmin == null)
            {
                return BadRequest("admin not found");

            }
            _context.Admins.Remove(dbAdmin);
            await _context.SaveChangesAsync();
            return Ok(await _context.Admins.ToListAsync());


        }

    }
}
