using kingsprinter.Backend.Models;
using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : Controller
    {
        private readonly AppDBContext _db;
        public SizeController(AppDBContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.PaperSizes.OrderBy(s => s.SizeName).ToListAsync());

        [HttpPost]
        public async Task<ActionResult<PaperSize>> Create(PaperSize pq)
        {
            _db.PaperSizes.Add(pq);
            await _db.SaveChangesAsync();
            return Ok(pq);
        }


    }
}