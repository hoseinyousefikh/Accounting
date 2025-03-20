using System.ComponentModel.DataAnnotations;

namespace AccountingMVC.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
