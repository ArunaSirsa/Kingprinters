namespace kingsprinter.Backend.Models
{
    public class DieCutShape
    {

        public int Id { get; set; }
        public string ShapeName { get; set; }
        public string? ImagePath { get; set; }
        public string Status { get; set; } = "A";   // A = Active, D = DeActive


    }
}
