using App.Domain.Core.Accounting.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace AccountingMVC.Models
{
    public class FundsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public PersonCondition PersonConditions { get; set; } 
    }
}
