using App.Domain.Core.Accounting.Entities.Enum;
using App.Domain.Core.Accounting.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.Entities.Budgetings
{

    public class Budgeting
    {
        public int Id { get; set; }
        public Timing timings { get; set; }
        public Xxpens Xxpenses { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal MinAmount { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "The amount must be between 0.01 and 100,000,000,000.")]
        public decimal MaxAmount { get; set; }
        public DateTime FDate { get; set; }
        public DateTime TDate { get; set; }
        public bool IsDeleted { get; set; }


        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
