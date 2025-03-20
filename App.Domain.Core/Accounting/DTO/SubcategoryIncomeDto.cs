using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Accounting.DTO
{
    public class SubcategoryIncomeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublic { get; set; }

        public int CategoryIncomeId { get; set; }
        public int UserId { get; set; }
    }
}
