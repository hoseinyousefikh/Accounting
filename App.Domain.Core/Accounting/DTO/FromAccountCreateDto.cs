using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.DTO
{
    public class FromAccountCreateDto
    {
        public int? AssetsId { get; set; }
        public int? BankId { get; set; }
        public int? CapitalId { get; set; }
        public int? CategoryCostId { get; set; }
        public int? CategoryIncomeId { get; set; }
        public int? DebtsId { get; set; }
        public int? FundsId { get; set; }
        public int? PersonsId { get; set; }
        public int? CriticismId { get; set; }
    }

}
