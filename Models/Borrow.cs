using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BorrowDateTime { get; set; }

        public DateTime? ReturnDate { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }
        public Book? Book { get; set; }
    }
}
