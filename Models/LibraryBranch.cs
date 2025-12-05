using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        // Initialize Name to prevent null (if Name is a required field)
        public required string Name { get; set; }  

        // Navigation property: list of books in this branch
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
