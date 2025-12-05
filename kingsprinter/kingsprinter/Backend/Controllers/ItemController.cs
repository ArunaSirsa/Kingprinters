using kingsprinter.Backend.Models;
using kingsprinter.Backend.Service.StaffService;
using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly AppDBContext _db;
        public ItemController(AppDBContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _db.Items.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _db.Items.FindAsync(id);
            return cat == null ? NotFound() : Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ItemService dto)
        {
            string? imagePath = null;

            if (dto.ImagePath != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ImagePath.FileName);
                var filePath = Path.Combine("wwwroot/Img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImagePath.CopyToAsync(stream);
                }

                imagePath = "/Img/" + fileName;
            }

            var item = new Item
            {
                Name = dto.Name,
                ImagePath = imagePath,
                status = "A"
            };

            _db.Items.Add(item);
            await _db.SaveChangesAsync();

            return Ok(item);
        }













        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Item model)
        {
            if (id != model.Id) return BadRequest();
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _db.Items.FindAsync(id);
            if (cat == null) return NotFound();
            _db.Items.Remove(cat);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
