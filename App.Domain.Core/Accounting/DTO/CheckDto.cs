using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.DTO
{
    public class CheckDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        [Required]
        public string ChecNumber { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DuDate { get; set; }

        public string? Description { get; set; }

        [Required]
        public int BankId { get; set; }

        public int? SubcategoryCostId { get; set; }
        public int? SubcategoryIncomeId { get; set; }
        public int? MemberId { get; set; }
        public int? EventId { get; set; }
        public int? ProjectId { get; set; }

        [Required(ErrorMessage = "Please select an expense type.")]
        public Xxpens Xxpenses { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
