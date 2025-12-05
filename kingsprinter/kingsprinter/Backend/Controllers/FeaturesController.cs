using kingsprinter.Backend.Models;
using kingsprinter.Backend.Service.StaffService;
using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public FeaturesController(AppDBContext context)
        {
            _context = context;
        }

        // 🔹 Get all subcategories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.features
                .Include(x => x.subCategory)
                .Select(x => new
                {
                    x.Id,
                     x.ProductCode,
                    subCategoryName = x.subCategory.Name,
                    x.LaminationType,
                    x.UVOption,
                    x.FoilOption,
                    x.DieCutOption,
                      x.ProductionTime
                })
                .ToListAsync();

            return Ok(data);
        }

        // 🔹 Get by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sub = await _context.Subcategories.FindAsync(id);
            if (sub == null) return NotFound();
            return Ok(sub);
        }

        // 🔹 Create
        [HttpPost]
        public async Task<IActionResult> Create(FeatureService dto)
        {
            var model = new Features
            {
                 SubCategoryId = dto.SubCategoryId,
                LaminationType = dto.LaminationType,
                UVOption= dto.UVOption,
                FoilOption= dto.FoilOption,
                DieCutOption= dto.DieCutOption,
                //TextureOption= dto.TextureOption,
                ProductionTime = dto.ProductionTime,
                ProductCode=dto.ProductCode,
                    
            };

            _context.features.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }


        // 🔹 Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Features model)
        {
            var existing = await _context.features.FindAsync(id);
            if (existing == null) return NotFound();

            existing.ProductCode = model.ProductCode;
            existing.SubCategoryId = model.SubCategoryId;
            existing.LaminationType = model.LaminationType;
            existing.UVOption = model.UVOption;
            existing.FoilOption = model.FoilOption;
            existing.DieCutOption = model.DieCutOption;
            //existing.TextureOption = model.TextureOption;
            existing.ProductionTime = model.ProductionTime;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Updated successfully!" });
        }

        // 🔹 Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _context.features.FindAsync(id);
            if (existing == null) return NotFound();

            _context.features.Remove(existing);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Deleted successfully!" });
        }
        [HttpGet("GetAllWithNames")]
        //public async Task<IActionResult> GetAllWithNames()
        //{
        //    var data = await _context.features
        //        .Include(c => c.LT)
        //        .Include(c => c.uV)
        //        .Include(c => c.Fo)
        //        .Include(c => c.dc)
        //        .Include(c => c.subCategory)
        //        .Select(c => new FeatureServicedto
        //        {
        //            ProductCode = c.ProductCode,
        //            ProductionTime = c.ProductionTime,

        //            LaminationType = c.LT != null ? c.LT.LaminationTypes : "N/A",
        //            UVOption = c.uV != null ? c.uV.UVOptionTypes : "N/A",
        //            FoilOption = c.Fo != null ? c.Fo.FoilOptionTypes : "N/A",
        //            DieCutOption = c.dc != null ? c.dc.DieCutOptionTypes : "N/A",

        //            SubCategory = c.subCategory != null ? c.subCategory.Name : "N/A"
        //        })
        //        .ToListAsync();

        //    return Ok(data);
        //}



        [HttpGet("GetAllWithSubNames")]
        public async Task<IActionResult> GetAllWithSubNames()
        {
            var data = await _context.features
               
                .Include(c => c.subCategory)
                .Select(c => new FeatureServicedto
                {
                    ProductCode = c.ProductCode,
                    ProductionTime = c.ProductionTime,
                    LaminationType=c.LaminationType,
                    UVOption=c.UVOption,
                    FoilOption=c.FoilOption,
                    DieCutOption=c.DieCutOption,
                   

                    SubCategory = c.subCategory != null ? c.subCategory.Name : "N/A"
                })
                .ToListAsync();

            return Ok(data);
        }
    }
}
