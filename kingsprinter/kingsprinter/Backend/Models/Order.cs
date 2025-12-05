using kingsprinter.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace kingsprinter.Backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime    orderdate { get; set; }
        public int? Productid { get; set; }
        public Product? Product { get; set; }
        public string ClientName { get; set; }
        public string Printing { get; set; }//single double
        public  string Whitebase { get; set; }
       // Front back
        public string SpotUV { get; set; }
        public string Foil { get; set; } // Front back
        public string FoilColour { get; set; }//gold silver red
        [ForeignKey("diecutshapeid")]
        public DieCutShape DiecutShape { get; set; }
        public int diecutshapeid { get; set; }
       
        public string FileOption { get; set; }
        public LaminationType laminationType { get; set; }
        public int laminationTypeid { get; set; }
       public int? TextureTypeid { get; set; }
        [ForeignKey("TextureTypeid")]
        public Texture texture { get; set; }

        public string PrivacyPacking { get; set; }
        public string Quantity { get; set; }
        public string Cost {  get; set; }
        public string GST {  get; set; }
        public string SpecialRemark  { get; set; }
        public string EnterPressline { get; set; }
        public string AmountPayable	 { get; set; }
        public string status = "A";
    }
}
