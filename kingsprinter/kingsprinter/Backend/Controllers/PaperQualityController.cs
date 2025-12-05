using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperQualityController : Controller
    {
      
         private readonly AppDBContext _context;

            public PaperQualityController(AppDBContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<PaperQuality>>> GetAll()
            {
                return await _context.PaperQualities.ToListAsync();
            }

            [HttpPost]
            public async Task<ActionResult<PaperQuality>> Create(PaperQuality pq)
            {
                _context.PaperQualities.Add(pq);
                await _context.SaveChangesAsync();
                return Ok(pq);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, PaperQuality pq)
            {
                if (id != pq.Id) return BadRequest();

                _context.Entry(pq).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var pq = await _context.PaperQualities.FindAsync(id);
                if (pq == null) return NotFound();

                _context.PaperQualities.Remove(pq);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }

