using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AmazeCareHMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } 

        [Required, MaxLength(20)]
        public string Role { get; set; }
        
        public Patient Patient { get; set; }  
        public Doctor Doctor { get; set; }    
    }
}
