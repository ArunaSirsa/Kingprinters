using kingsprinter.Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kingsprinter.Models
{
    public class SubCategory
    {
        
        public int Id { get; set; }

      
        public string Name { get; set; }  // e.g. 800 GSM Black Sheet

        
        // Foreign Key for Category
        public int CategoryId { get; set; }

   
        public Category? Category { get; set; }
        public string status { get; set; } = "A";
       
    }
}

