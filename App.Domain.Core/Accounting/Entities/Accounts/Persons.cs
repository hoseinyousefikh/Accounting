using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Accounts
{
    public class Persons
    {
        public int Id { get; set; }
        public int? ContactsId { get; set; }
        public Contacts? Contacts { get; set; } 
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public int? PhonNumber { get; set; }
        public string? Description { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublic { get; set; }

        public PersonCondition PersonConditions { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
