using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class UserModel
    {
        [Key] // 👈 Ye primary key define karta hai
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? ContactNumber { get; set; }

        [Required]
        public string? CountryCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        public string? Role { get; set; }
    }
}
