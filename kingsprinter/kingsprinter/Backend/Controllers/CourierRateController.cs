using kingsprinter.Data;
using kingsprinter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace kingsprinter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierRateController : ControllerBase
    {
        private readonly AppDBContext _db; // ya jo bhi tumhara context name ho

        public CourierRateController(AppDBContext db)
        {
            _db = db;
        }

        [HttpPost("Create")]
        //public async Task<IActionResult> Create([FromBody] CourierPrice model)
        //{
        //    if (model == null)
        //        return BadRequest("Invalid data");

        //    _db.CourierPrices.Add(model);
        //    await _db.SaveChangesAsync();

        //    return Ok(model);
        //}

        public IActionResult Create([FromBody] CourierPrice cp)
        {
            if (cp == null) return BadRequest();


            var state = _db.States.Find(cp.StateId);
            if (state == null)
                return BadRequest("Invalid SateId");

            cp.State = state; // attach existing category
            _db.CourierPrices.Add(cp);
            _db.SaveChanges();

            return Ok("CourierPrice added successfully!");
        }
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<CourierPrice> prices)
        {
            if (prices == null || !prices.Any())
                return BadRequest("No data received.");

            // Ensure EF doesn’t try to insert State or PaperQuality
            foreach (var price in prices)
            {
                price.State = null;
                price.PaperQuality = null;
            }

            _db.CourierPrices.AddRange(prices);
            await _db.SaveChangesAsync();

            return Ok("Courier rates saved successfully!");
        }











        // Update a rate
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourierPrice model)
        {
            if (id != model.Id) return BadRequest();
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Get rates raw (optional)
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.CourierPrices.Include(r => r.State).ToListAsync());

        // Matrix API for frontend: returns quantities, states and rates grouped
        [HttpGet("matrix")]
        public async Task<IActionResult> GetMatrix()
        {
            // get states
            var states = await _db.States.OrderBy(s => s.Name).Select(s => new { s.Id, s.Name }).ToListAsync();

            // get unique quantities for current PaperQuality (optionally filter by PaperQualityId)
            var quantities = await _db.CourierPrices.Select(r => r.Quantity).Distinct().OrderBy(q => q).ToListAsync();

            // get all rates
            var rates = await _db.CourierPrices.ToListAsync();

            // build matrix
            var matrix = quantities.Select(q => new
            {
                Quantity = q,
                Rates = states.Select(s =>
                {
                    var r = rates.FirstOrDefault(x => x.Quantity == q && x.StateId == s.Id);
                    return new { StateId = s.Id, StateName = s.Name, Rate = r?.Rate ?? 0M, RateId = r?.Id };
                })
            });

            return Ok(new { States = states, Matrix = matrix });
        }
    }
}