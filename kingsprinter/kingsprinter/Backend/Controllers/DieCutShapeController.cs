using kingsprinter.Backend.Models;
using kingsprinter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class DieCutShapeController : ControllerBase
        {
            private readonly AppDBContext _db;

            public DieCutShapeController(AppDBContext db)
            {
                _db = db;
            }

            // Create Shape
            [HttpPost("Create")]
            public async Task<IActionResult> Create([FromForm] DieCutShape model, IFormFile? image)
            {
                if (image != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine("wwwroot/DieCutImages", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    model.ImagePath = "/DieCutImages/" + fileName;
                }

                _db.dieCutShapes.Add(model);
                await _db.SaveChangesAsync();
                return Ok(model);
            }

            // Get All Shapes
            [HttpGet("GetAll")]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _db.dieCutShapes.ToListAsync());
            }

            // Update Shape
            [HttpPut("Update/{id}")]
            public async Task<IActionResult> Update(int id, [FromForm] DieCutShape model, IFormFile? image)
            {
                var shape = await _db.dieCutShapes.FindAsync(id);
                if (shape == null) return NotFound();

                shape.ShapeName = model.ShapeName;
                shape.Status = model.Status;

                if (image != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine("wwwroot/DieCutImages", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    shape.ImagePath = "/DieCutImages/" + fileName;
                }

                await _db.SaveChangesAsync();
                return Ok(shape);
            }

            // Delete
            [HttpDelete("Delete/{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var shape = await _db.dieCutShapes.FindAsync(id);
                if (shape == null) return NotFound();

                _db.dieCutShapes.Remove(shape);
                await _db.SaveChangesAsync();
                return Ok("Deleted");
            }
        }
    }

