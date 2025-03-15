using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Accounting.Entities.Users;

namespace App.Domain.Core.Accounting.Entities.Accounts.Sub
{
    public class SubcategoryIncome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublic { get; set; }


        public int CategoryIncomeId { get; set; } 
        public CategoryIncome CategoryIncome { get; set; } 

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
