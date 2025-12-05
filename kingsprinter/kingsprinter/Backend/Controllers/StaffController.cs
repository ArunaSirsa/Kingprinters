using kingsprinter.Data;
using kingsprinter.Models;
using kingsprinter.Service.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
   
        private readonly AppDBContext _context;

        public StaffController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetCustomers()
        {
            return await _context.Staffs.ToListAsync();
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var customer = await _context.Staffs.FindAsync(id);
            if (customer == null)
                return NotFound();

            return customer;
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStaff), new { id = staff.Id }, staff);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstaff(int id, Staff staff)
        {
            if (id != staff.Id)
                return BadRequest();

            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var customer = await _context.Staffs.FindAsync(id);
            if (customer == null)
                return NotFound();

            _context.Staffs.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] StaffService loginData)
        {
            var staff = _context.Staffs
                .FirstOrDefault(x => x.Username == loginData.Username && x.Password == loginData.Password);

            if (staff == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            //var response = new
            //{
            //    Username
            //    = staff.Username,
            //    password=staff.Password,
            //};
            return Ok(new { message = "Login successful", staff });
        }
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] Changepassword model)
        {
            var staff = _context.Staffs
                .FirstOrDefault(x => x.Username == model.Username && x.Password == model.OldPassword);

            if (staff == null)
            {
                return BadRequest(new { message = "Invalid username or old password" });
            }

            staff.Password = model.NewPassword;
            _context.SaveChanges();

            return Ok(new { message = "Password changed successfully" });
        }
    }
}