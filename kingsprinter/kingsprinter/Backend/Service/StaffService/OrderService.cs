using kingsprinter.Backend.Models;

namespace kingsprinter.Backend.Service.StaffService
{
    public class OrderService
    {
        public int Productid { get; set; }
        public DateTime    orderdate { get; set; }

        public string ClientName { get; set; }
        public string Printing { get; set; }//single double
        public string Whitebase { get; set; }
        // Front back
        public string SpotUV { get; set; }
        public string Foil { get; set; } // Front back
        public string FoilColour { get; set; }//gold silver red
       
        public int diecutshapeid { get; set; }

        public string FileOption { get; set; }
        public int laminationTypeid { get; set; } = 0;
        public int TextureTypeid { get; set; }   
        public string PrivacyPacking { get; set; }
        public string Quantity { get; set; }
        public string Cost { get; set; }
        public string GST { get; set; }
        public string SpecialRemark { get; set; }
        public string EnterPressline { get; set; }
        public string AmountPayable { get; set; }
        public string status = "A";
    }
}
