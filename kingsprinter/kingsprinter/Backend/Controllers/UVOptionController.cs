using kingsprinter.Backend.Models;
using kingsprinter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UVOptionController : Controller
    {
        private readonly AppDBContext _context;

        public UVOptionController(AppDBContext context)
        {
            _context = context;
        }

        // ✅ Get All UV Types
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UVOption>>> GetAll()
        {
            return await _context.uVOptions.ToListAsync();
        }

        // ✅ Create Foiltype Type
        [HttpPost]
        public async Task<ActionResult<UVOption>> Create(UVOption pq)
        {
            _context.uVOptions.Add(pq);
            await _context.SaveChangesAsync();
            return Ok(pq);
        }

        // ✅ Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UVOption pq)
        {
            if (id != pq.Id) return BadRequest();

            _context.Entry(pq).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        // ✅ Soft Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lam = await _context.uVOptions.FindAsync(id);

            if (lam == null)
                return NotFound();

            lam.status = "D";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Foil Type Deleted!" });
        }
    }
}
