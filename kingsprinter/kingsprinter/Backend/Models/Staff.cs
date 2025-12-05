using System.Net.NetworkInformation;

namespace kingsprinter.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public  string? Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pin { get; set; }
        public string? Country { get; set; }
        public string? Business { get; set; }
        public string? GST { get; set; }
        public string? Bank{ get; set; }
        public string? Branch { get; set; }
        public string? IFSC { get; set; }
        public string? AccountNo { get; set; }
        public string? stafftype { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }
       public string status { get; set; }= "A";



    }
}
