using kingsprinter.Backend.Models;
using kingsprinter.Backend.Service.StaffService;
using kingsprinter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly AppDBContext _db;
        public OrderController(AppDBContext db) => _db = db;







        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _db.orders
                                .Include(c => c.DiecutShape )
                                .Include(c =>c. laminationType)
                                .Include(c =>c.texture)
                                .Select(c => new
                                {
                                    c.Id,
                                    c.orderdate,
                                    c.ClientName,
                                    c.PrivacyPacking,
                                    c.Quantity,
                                    
                                    c.FileOption,
                                    c.Whitebase,
                                    c.SpotUV,
                                    c.DiecutShape,
                                    c.Foil,
                                    c.FoilColour,
                                    c.Printing,
                                    c.Cost,
                                    c.GST,
                                    c.AmountPayable,
                                    c.EnterPressline,
                                    c.SpecialRemark,
                                    LaminationType=c.laminationTypeid!=null?c.laminationType.LaminationTypes:null,
                                Texture=c.TextureTypeid!=null ?c.texture.Texturename :null,
                                    DieCutShape = c.diecutshapeid != null ? c.DiecutShape.ShapeName: null
                                })// Include related Item
                                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _db.orders.FindAsync(id);
            return cat == null ? NotFound() : Ok(cat);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderService dto)
        {
            var model = new Order
            {
              ClientName=  dto.ClientName,
              orderdate=dto.orderdate,
                                 PrivacyPacking=   dto.PrivacyPacking,
                                    Quantity = dto.Quantity,
                                    FileOption = dto.FileOption,
                                    Whitebase = dto.Whitebase,
                                    SpotUV = dto.SpotUV,
                                    diecutshapeid = dto.diecutshapeid,
                                    laminationTypeid = dto.laminationTypeid,
                                    Foil = dto.Foil,
                                    FoilColour = dto.FoilColour,
                                    Printing = dto.Printing,
                                    Cost = dto.Cost,
                                    GST = dto.GST,
                                    Productid=dto.Productid,
                                    AmountPayable = dto.AmountPayable,
                                    EnterPressline = dto.EnterPressline,
                                    SpecialRemark = dto.SpecialRemark,

                TextureTypeid = dto.TextureTypeid,

                status = "A"
            };

            _db.orders.Add(model);
            await _db.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order model)
        {
            if (id != model.Id) return BadRequest();
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _db.orders.FindAsync(id);
            if (cat == null) return NotFound();
            _db.orders.Remove(cat);
            await _db.SaveChangesAsync();
            return NoContent();
        }



        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByDate(DateTime orderdate)
        {
            var data = await _db.orders
                                .Include(c => c.DiecutShape)
                                .Include(c => c.laminationType)
                                .Include(c => c.texture)
                                .Select(c => new
                                {
                                    c.Id,
                                    c.orderdate,
                                    c.ClientName,
                                    c.PrivacyPacking,
                                    c.Quantity,

                                    c.FileOption,
                                    c.Whitebase,
                                    c.SpotUV,
                                  
                                    c.Foil,
                                    c.FoilColour,
                                    c.Printing,
                                    c.Cost,
                                    c.GST,
                                    c.AmountPayable,
                                    c.EnterPressline,
                                    c.SpecialRemark,
                                    LaminationType = c.laminationTypeid != null ? c.laminationType.LaminationTypes : null,
                                    Texture = c.TextureTypeid != null ? c.texture.Texturename : null,
                                    DieCutShape = c.diecutshapeid != null ? c.DiecutShape.ShapeName : null
                                })// Include related Item
                                .ToListAsync();
            return Ok(data);
        }
        //[HttpGet("GetByItem/{subcatid}")]
        //public async Task<IActionResult> GetByItem(int subcatid)
        //{
        //    var products = await _db.products
        //        .Where(c => c.Subcatid == subcatid && c.status == "A")
        //        .Select(c => new
        //        {
        //            c.Id,
        //            c.ProductName
        //        })
        //        .ToListAsync();

        //    return Ok(products);
        //}
        //*...........SubCategiry................                */




    }
}
