using kingsprinter.Backend.Models;
using kingsprinter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class DieCutOptionTypesController : ControllerBase
        {
            private readonly AppDBContext _context;

            public DieCutOptionTypesController(AppDBContext context)
            {
                _context = context;
            }

            // ✅ Get All Lamination Types
            [HttpGet]
            [HttpGet]
            public async Task<ActionResult<IEnumerable<DieCutOption>>> GetAll()
            {
                return await _context.dieCutOptions.ToListAsync();
            }

            // ✅ Create Lamination Type
            [HttpPost]
            public async Task<ActionResult<DieCutOption>> Create(DieCutOption pq)
            {
                _context.dieCutOptions.Add(pq);
                await _context.SaveChangesAsync();
                return Ok(pq);
            }

            // ✅ Update

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, DieCutOption pq)
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
                var lam = await _context.dieCutOptions.FindAsync(id);

                if (lam == null)
                    return NotFound();

                lam.status = "D";
                await _context.SaveChangesAsync();

                return Ok(new { message = "DieCut Type Deleted!" });
            }
        }
    }

