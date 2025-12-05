using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public required string Biography { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
