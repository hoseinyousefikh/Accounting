using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.Accounts
{
    public class Assets
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public PersonCondition personConditions { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
