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
    public class ProductController : ControllerBase
    {

        private readonly AppDBContext _db;
        public ProductController(AppDBContext db) => _db = db;







        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _db.products
                                .Include(c => c.SubCategoryId)
                                .Select(c => new
                                {
                                    c.Id,
                                    c.ProductName,
                                    c.laminationType,
                                    c.PaperQualilty,
                                    c.TextureType,
                                    c.ProductCode,c.ProductRef,c.SpotUV,c.DieShape,c.Foil,c.FoilColour,c.Printing,
                                    SubCategory = c.SubCategoryId != null ? c.SubCategory.Name : null
                                })// Include related Item
                                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _db.products.FindAsync(id);
            return cat == null ? NotFound() : Ok(cat);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductService dto)
        {
            var model = new Product
            {
                ProductName = dto.ProductName,
                SubCategoryId = dto.SubCategoryId,
                Printing=dto.Printing,
                SpotUV=dto.SpotUV,
                DieShape=dto.DieShape,
                FoilColour=dto.FoilColour,
                Foil=dto.Foil,
                ProductRef=dto.ProductRef,
                ProductCode=dto.ProductCode,
                laminationType=dto.laminationType,
                TextureType=dto.TextureType,
                PaperQualilty=dto.PaperQualilty,

                status = "A"
            };

            _db.products.Add(model);
            await _db.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product model)
        {
            if (id != model.Id) return BadRequest();
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _db.products.FindAsync(id);
            if (cat == null) return NotFound();
            _db.products.Remove(cat);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("GetByItem/{subcatid}")]
        public async Task<IActionResult> GetByItem(int subcatid)
        {
            var products = await _db.products
                .Where(c => c.SubCategoryId == subcatid && c.status == "A")
                .Select(c => new
                {
                    c.Id,
                    c.ProductName
                })
                .ToListAsync();

            return Ok(products);
        }
        //*...........SubCategiry................                */



    }
}

