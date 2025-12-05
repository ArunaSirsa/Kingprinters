using kingsprinter.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace kingsprinter.Backend.Service.StaffService
{
    public class CityService
    {
        public string city { get; set; }
     
        public int stateid { get; set; }


        public string status { get; set; } = "A";
    }
}
