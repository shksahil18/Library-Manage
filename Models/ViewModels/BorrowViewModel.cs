// Models/ViewModels/BorrowViewModel.cs
namespace LibraryManagementSystem.Models.ViewModels
{
    public class BorrowViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public DateTime BorrowDateTime { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
