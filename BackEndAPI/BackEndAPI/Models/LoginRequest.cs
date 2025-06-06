using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
} 