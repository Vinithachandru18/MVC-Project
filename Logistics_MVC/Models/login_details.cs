using System.ComponentModel.DataAnnotations;

namespace Logistics_MVC.Models
{
    public class login_details
    {
        [Key]
        public int userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
