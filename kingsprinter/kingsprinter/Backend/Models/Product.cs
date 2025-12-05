using kingsprinter.Models;

namespace kingsprinter.Backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public string ProductName { get; set; }
        public string Printing { get; set; }
        public string SpotUV { get; set; }
        public string Foil {  get; set; }
        public string FoilColour { get; set; }
        public string DieShape { get; set; }
        public string ProductRef { get; set; }
        public string ProductCode { get; set; }
        public string laminationType { get; set; }  
        public string TextureType {  get; set; }
        public string PaperQualilty { get; set; }

        public string status = "A";
    }
}
