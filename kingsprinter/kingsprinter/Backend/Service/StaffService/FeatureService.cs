using kingsprinter.Models;

namespace kingsprinter.Backend.Service.StaffService
{
    public class FeatureService
    {
             public int ProductCode { get; set; } // e.g. 2

        public int SubCategoryId { get; set; }
      

        public string  LaminationType { get; set; } // e.g. Velvet, Matt, Not Available
        public string UVOption { get; set; } // e.g. Available, Not Available
        public string FoilOption { get; set; } // e.g. Available (5 types)
        public string DieCutOption { get; set; } // e.g. Available (36 types)
             public int ProductionTime { get; set; } // e.g. 3 (days)
    }


    public class FeatureServicedto
    {
        public int ProductCode { get; set; } // e.g. 2

        public string SubCategory { get; set; }


        public String LaminationType { get; set; } // e.g. Velvet, Matt, Not Available
        public string UVOption { get; set; } // e.g. Available, Not Available
        public string FoilOption { get; set; } // e.g. Available (5 types)
        public string DieCutOption { get; set; } // e.g. Available (36 types)
        public int ProductionTime { get; set; } // e.g. 3 (days)
    }
}
