using kingsprinter.Backend.Models;
using kingsprinter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kingsprinter.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : Controller
    {
        private readonly AppDBContext _context;

        public ProductPriceController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost("UploadExcel")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Excel file not found");

            List<ProductPrice> priceList = new List<ProductPrice>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new OfficeOpenXml.ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];  // first sheet
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)  // row 1 = header
                    {
                        var price = new ProductPrice
                        {
                            //  Id = int.Parse(worksheet.Cells[row, 1].Value?.ToString() ?? "0"),

                            ItemId = SafeInt(worksheet.Cells[row, 2].Value),
                            Name = worksheet.Cells[row, 3].Value?.ToString(),
                            LONG_ID = SafeInt(worksheet.Cells[row, 4].Value),
                            OPTIONS = worksheet.Cells[row, 5].Value?.ToString(),
                            QTY = worksheet.Cells[row, 6].Value?.ToString(),
                            COST = worksheet.Cells[row, 7].Value?.ToString(),
                            CARRIAGE = worksheet.Cells[row, 8].Value?.ToString(),
                            Margin = worksheet.Cells[row, 9].Value?.ToString(),
                            GST = worksheet.Cells[row, 10].Value?.ToString(),
                            UpDate = DateTime.Now
                        };

                        priceList.Add(price);
                    }
                }
            }

            _context.productPrices.AddRange(priceList);
            await _context.SaveChangesAsync();

            return Ok("Excel uploaded successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.productPrices
                .Select(x => new {
                    x.Id,
                    x.ItemId,
                    x.Name,
                    x.LONG_ID,
                    x.OPTIONS,
                    x.QTY,
                    x.COST,
                    x.CARRIAGE,
                    x.Margin,
                    x.GST,
                    UpDate = x.UpDate.ToString("dd-MM-yyyy")  // <-- Format here
                })
                .ToListAsync();

            return Ok(data);
        }


        private int SafeInt(object value)
        {
            if (value == null) return 0;
            int.TryParse(value.ToString(), out int result);
            return result;
        }
    }
}
