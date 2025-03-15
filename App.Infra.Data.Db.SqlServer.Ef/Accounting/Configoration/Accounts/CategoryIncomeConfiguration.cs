using App.Domain.Core.Accounting.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Accounts
{
    public class CategoryIncomeConfiguration : IEntityTypeConfiguration<CategoryIncome>
    {
        public void Configure(EntityTypeBuilder<CategoryIncome> builder)
        {
            builder.ToTable("CategoryIncomes");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ci => ci.IsDeleted)
                .IsRequired();
            builder.Property(sc => sc.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(sc => sc.IsPublic)
                .HasDefaultValue(true);

            builder.HasMany(ci => ci.SubcategoryIncomes)
                .WithOne()
                .HasForeignKey(si => si.CategoryIncomeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ci => ci.Users)
                .WithMany(ci => ci.CategoryIncomes)
                .HasForeignKey(ci => ci.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new CategoryIncome { Id = 1, Name = "حقوق", IsDeleted = false, IsPublic = true, UserId = 1 },
                new CategoryIncome { Id = 2, Name = "فروش", IsDeleted = false, IsPublic = true, UserId = 1 },
                new CategoryIncome { Id = 3, Name = "سود سرمایه", IsDeleted = false, IsPublic = true, UserId = 1 },
                new CategoryIncome { Id = 4, Name = "یارانه و هدایا", IsDeleted = false, IsPublic = true, UserId = 1 },
                new CategoryIncome { Id = 5, Name = "درآمد اجاره", IsDeleted = false, IsPublic = true, UserId = 1 }
            );
        }
    }
}
