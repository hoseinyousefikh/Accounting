using App.Domain.Core.Accounting.DTO;
using App.Domain.Core.Accounting.Entities.Accounts;
using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.payment;
using App.Domain.Core.Accounting.Entities.PMEList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Domain.Core.Accounting.Maper
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Check, CheckDto>().ReverseMap();
            CreateMap<CategoryIncome, CategoryIncomeDto>().ReverseMap();
            CreateMap<SubcategoryIncome, SubcategoryIncomeDto>().ReverseMap();

        }
    }

}
