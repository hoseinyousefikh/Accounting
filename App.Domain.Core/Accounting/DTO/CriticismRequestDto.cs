using App.Domain.Core.Accounting.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.DTO
{
    public class CriticismRequestDto
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int? SubcategoryCostId { get; set; }
        public int? SubcategoryIncomeId { get; set; }
        public int? MemderId { get; set; }
        public int? EventId { get; set; }
        public int? ProjectId { get; set; }
        public int UserId { get; set; }
        public int FromAccountId { get; set; }
        public Xxpens Xxpenses { get; set; }

    }
}
