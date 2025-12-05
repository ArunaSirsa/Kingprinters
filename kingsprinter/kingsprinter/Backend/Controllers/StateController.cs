using kingsprinter.Backend.Models;
using kingsprinter.Backend.Service.StaffService;
using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly AppDBContext _db;
        public StateController(AppDBContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.States.OrderBy(s => s.Name).ToListAsync());

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] State model)
        {
            if (string.IsNullOrWhiteSpace(model.Name)) return BadRequest("Name required");
            var exists = await _db.States.AnyAsync(s => s.Name == model.Name);
            if (exists) return BadRequest("State already exists");
            _db.States.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = model.Id }, model);
        }


        [HttpPost("CreateCity")]
        public async Task<IActionResult> Create(CityService dto)
        {
            var model = new City
            {
                city = dto.city,
                stateid = dto.stateid,
                status = "A"
            };

            _db.Cities.Add(model);
            await _db.SaveChangesAsync();

            return Ok(model);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCity()
        {
            var data = await _db.Cities
                                .Include(c => c.state)
                                .Select(c => new
                                {
                                    c.Id,
                                    c.city,
                                    name = c.state != null ? c.state.Name : null
                                })// Include related Item
                                .ToListAsync();
            return Ok(data);
        }
    }
}

