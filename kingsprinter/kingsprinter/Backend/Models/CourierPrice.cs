namespace kingsprinter.Models
{
    public class CourierPrice
    {
        public int Id { get; set; }
        public int PaperQualityId { get; set; }     // optional FK if you have PaperQuality table
        public int Quantity { get; set; }           // e.g. 1000,2000,...
        public int StateId { get; set; }            // FK to State
        public decimal Rate { get; set; }

        // navigation
        public State? State { get; set; }
        public PaperQuality? PaperQuality { get; set; }
       public string status { get; set; }= "A";

    }
}
