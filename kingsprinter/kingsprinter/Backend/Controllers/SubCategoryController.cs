using kingsprinter.Backend.Service.StaffService;
using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SubCategoryController(AppDBContext context)
        {
            _context = context;
        }

        // ✅ GET All SubCategories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Subcategories
                .Include(x => x.Category)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                   
                   
                })
                .ToListAsync();

            return Ok(data);
        }

        // ✅ GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetSubCategory(int id)
        {
            var subCategory = await _context.Subcategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subCategory == null)
                return NotFound();

            return subCategory;
        }

        // ✅ POST (Create)
        [HttpPost ("Create")]

        public async Task<IActionResult> Create(SubcategoryService dto)
        {
            var model = new SubCategory
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                status = "A"
            };

            _context.Subcategories.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
        // ✅ PUT (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
                return BadRequest();

            _context.Entry(subCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await _context.Subcategories.FindAsync(id);
            if (subCategory == null)
                return NotFound();

            _context.Subcategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetAllWithDetails")]
        public IActionResult GetAllWithDetails()
        {
            var data = _context.Subcategories
                .Include(s => s.Category)
                .ThenInclude(c => c.Item)
                .Select(s => new {
                    SubCategoryId = s.Id,
                    SubCategoryName = s.Name,
                    CategoryName = s.Category.name,
                    ItemName = s.Category.Item.Name
                })
                .ToList();

            return Ok(data);
        }



        [HttpGet("GetByCategory/{catid}")]
        public async Task<IActionResult> GetByCat(int catid)
        {
            var scategories = await _context.Subcategories
                .Where(c => c.CategoryId == catid && c.status == "A")
                .Select(c => new
                {
                    c.Id,
                    c.Name
                })
                .ToListAsync();

            return Ok(scategories);
        }
    }
}