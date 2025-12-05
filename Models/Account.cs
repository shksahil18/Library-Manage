using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;  // Ensuring non-null value

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;  // Ensuring non-null value
    }
}
