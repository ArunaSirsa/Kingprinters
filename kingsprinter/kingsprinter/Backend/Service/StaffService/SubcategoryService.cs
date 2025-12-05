using kingsprinter.Models;

namespace kingsprinter.Backend.Service.StaffService
{
    public class SubcategoryService
    {
        public string Name { get; set; }  // e.g. 800 GSM Black Sheet


        // Foreign Key for Category
        public int CategoryId { get; set; }


        
        public string status { get; set; } = "A";
    }
}
