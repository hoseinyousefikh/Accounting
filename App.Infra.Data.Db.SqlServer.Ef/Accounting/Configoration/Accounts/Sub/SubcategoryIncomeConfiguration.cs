using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Accounts.Sub
{
    public class SubcategoryIncomeConfiguration : IEntityTypeConfiguration<SubcategoryIncome>
    {
        public void Configure(EntityTypeBuilder<SubcategoryIncome> builder)
        {
            builder.ToTable("SubcategoryIncomes");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(ad => ad.Amount)
               .IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(si => si.IsDeleted)
                .IsRequired();
            builder.Property(sc => sc.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(sc => sc.IsPublic)
                .HasDefaultValue(true);

            builder.HasOne(si => si.CategoryIncome) 
                   .WithMany(ci => ci.SubcategoryIncomes)
                   .HasForeignKey(si => si.CategoryIncomeId)  
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(si => si.Users)
                .WithMany(u => u.SubcategoryIncomes)
                .HasForeignKey(si => si.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(
     // For Category "حقوق"
     new SubcategoryIncome { Id = 1, Name = "حقوق ماهیانه", CategoryIncomeId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 2, Name = "عیدی", CategoryIncomeId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 3, Name = "پاداش", CategoryIncomeId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 4, Name = "مزایا", CategoryIncomeId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 5, Name = "سایر حقوق", CategoryIncomeId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "فروش"
     new SubcategoryIncome { Id = 6, Name = "لوازم", CategoryIncomeId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 7, Name = "مسکن", CategoryIncomeId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 8, Name = "خودرو", CategoryIncomeId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 9, Name = "سایر فروش", CategoryIncomeId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "سود سرمایه"
     new SubcategoryIncome { Id = 10, Name = "سود سپرده بانکی", CategoryIncomeId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 11, Name = "سود اوراق مشارکت", CategoryIncomeId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 12, Name = "سود سهام", CategoryIncomeId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 13, Name = "سایر سود سرمایه", CategoryIncomeId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "یارانه و هدایا"
     new SubcategoryIncome { Id = 14, Name = "یارانه نقدی", CategoryIncomeId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 15, Name = "هدیه", CategoryIncomeId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 16, Name = "سایر یارانه و هدایا", CategoryIncomeId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "درآمد اجاره"
     new SubcategoryIncome { Id = 17, Name = "اجاره آپارتمان", CategoryIncomeId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 18, Name = "اجاره مغازه", CategoryIncomeId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 19, Name = "اجاره شرکت", CategoryIncomeId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryIncome { Id = 20, Name = "سایر درآمد اجاره", CategoryIncomeId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 }
 );

        }
    }
}
