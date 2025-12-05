using kingsprinter.Models;

namespace kingsprinter.Backend.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
  public string Name { get; set; }
        public int LONG_ID { get; set; }
        public string OPTIONS { get; set; }
        public string QTY { get; set; }
        public string COST { get; set; }
        public string CARRIAGE    { get; set; }
        public string Margin  { get; set; }
        public string GST { get; set; }
        public DateTime UpDate { get; set; }
       
    }
}
