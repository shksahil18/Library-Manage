using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModels
{
    public class BorrowModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; }
        
        public required List<SelectListItem> CustomerList { get; set; } = new();
        public required List<SelectListItem> BookList { get; set; }  = new();
        
    }
}
