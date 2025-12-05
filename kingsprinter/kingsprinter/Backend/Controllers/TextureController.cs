using kingsprinter.Backend.Models;
using kingsprinter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextureController : Controller
    {
        private readonly AppDBContext _context;

        public TextureController(AppDBContext context)
        {
            _context = context;
        }

        // ✅ Get All Lamination Types
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Texture>>> GetAll()
        {
            return await _context.textures.ToListAsync();
        }

        // ✅ Create Foiltype Type
        [HttpPost]
        public async Task<ActionResult<Texture>> Create(Texture pq)
        {
            _context.textures.Add(pq);
            await _context.SaveChangesAsync();
            return Ok(pq);
        }

        // ✅ Update

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Texture pq)
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
            var lam = await _context.textures.FindAsync(id);

            if (lam == null)
                return NotFound();

            lam.status = "D";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Foil Type Deleted!" });
        }
    }
}

