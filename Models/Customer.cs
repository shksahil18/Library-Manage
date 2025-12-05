using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Phone { get; set; }

        // 🔧 Add missing property
        [DataType(DataType.DateTime)]
        [Display(Name = "Membership Date")]
        public DateTime MembershipDate { get; set; }

        [Required]
        [Display(Name = "Membership Plan")]
        public required string Plan { get; set; }
    }
}
