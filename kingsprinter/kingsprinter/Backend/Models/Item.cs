using kingsprinter.Models;

namespace kingsprinter.Backend.Models
{
    public class Item
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
        public string? ImagePath { get; set; }


        public string status { get; set; } = "A";


             public ICollection<Category> Categories { get; set; }
        
    }
}
