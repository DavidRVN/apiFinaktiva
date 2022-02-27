using System.ComponentModel.DataAnnotations;

namespace apiFinaktiva.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string user { get; set; } 
        public string password { get; set; }
        public string rol { get; set; }
        public string token { get; set; }

    }
}
