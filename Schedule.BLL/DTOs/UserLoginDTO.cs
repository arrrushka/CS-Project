using System.ComponentModel.DataAnnotations;

namespace ProjectV2.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}