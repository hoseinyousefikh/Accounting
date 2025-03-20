using App.Domain.Core.Accounting.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.Accounts
{
    public class Bank
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Oranches { get; set; }
        public int AccountNumber { get; set; }
        public long CardNumber { get; set; }
        public long ShabaNumber { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublic { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}