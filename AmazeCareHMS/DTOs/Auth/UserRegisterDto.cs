using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Auth
{
    public class UserRegisterDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Role { get; set; } // "Patient" or "Doctor"
    }
}
