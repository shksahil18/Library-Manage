using System.ComponentModel.DataAnnotations;


namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Author { get; set; }

        [Required]
        public required string ISBN { get; set; }

        [Required]
        public int PublishedYear { get; set; }

        [Required]
        public required string Genre { get; set; }
        public int Year { get; set; }  // for backward compatibility in views
        public required string Description { get; set; } 

    }
}
