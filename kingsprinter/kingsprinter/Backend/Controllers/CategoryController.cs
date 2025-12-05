using kingsprinter.Backend.Service.StaffService;
using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace kingsprinter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDBContext _db;
        public CategoryController(AppDBContext db) => _db = db;







        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _db.Categories
                                .Include(c => c.Item) 
                                .Select(c => new
                                {
                                    c.Id,
                                    c.name,
                                  ItemName=c.Item!=null?c.Item.Name:null
                                })// Include related Item
                                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _db.Categories.FindAsync(id);
            return cat == null ? NotFound() : Ok(cat);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryService dto)
        {
            var model = new Category
            {
                name = dto.CategoryName,
                ItemId = dto.ItemId,
                status = "A"
            };

            _db.Categories.Add(model);
            await _db.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category model)
        {
            if (id != model.Id) return BadRequest();
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _db.Categories.FindAsync(id);
            if (cat == null) return NotFound();
            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("GetByItem/{itemId}")]
        public async Task<IActionResult> GetByItem(int itemId)
        {
            var categories = await _db.Categories
                .Where(c => c.ItemId == itemId && c.status == "A")
                .Select(c => new
                {
                    c.Id,
                    c.name
                })
                .ToListAsync();

            return Ok(categories);
        }
        //*...........SubCategiry................                */



    }
}