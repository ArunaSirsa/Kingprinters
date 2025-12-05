using kingsprinter.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace kingsprinter.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
       public string status { get; set; }= "A";
        public int ItemId { get; set; }

    
        public Item Item { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
