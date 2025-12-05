using kingsprinter.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace kingsprinter.Backend.Models
{
    public class City
    {
        public int Id { get; set; }
        public string city { get; set; }
        [ForeignKey("stateid")]
        public State state { get; set; }
        public int stateid { get; set; }


        public string status { get; set; } = "A";
    }
}
