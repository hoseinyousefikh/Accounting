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
    public class CategoryCostConfiguration : IEntityTypeConfiguration<CategoryCost>
    {
        public void Configure(EntityTypeBuilder<CategoryCost> builder)
        {
            builder.ToTable("CategoryCosts");

            builder.HasKey(cc => cc.Id);

            builder.Property(cc => cc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cc => cc.IsDeleted)
                .IsRequired();
            builder.Property(sc => sc.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(sc => sc.IsPublic)
                .HasDefaultValue(true);

            builder.HasMany(cc => cc.SubcategoryCosts)
                .WithOne()
                .HasForeignKey(sc => sc.CategoryCostId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(cc => cc.Users)
                .WithMany(cc=>cc.CategoryCosts)
                .HasForeignKey(cc => cc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
            new CategoryCost { Id = 1, Name = "اغذیه", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 2, Name = "مسکن", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 3, Name = "البسه و پوشاک", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 4, Name = "خودرو", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 5, Name = "ایاب و ذهاب مسافرت", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 6, Name = "اموزش و تحصیلات", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 7, Name = "فرهنگی و سرگرمی", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 8, Name = "هدایا", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 9, Name = "بهداشتی درمانی", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 10, Name = "هزینه های اداری", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 11, Name = "دیون اسلامی", IsDeleted = false, IsPublic = true, UserId = 1 },
            new CategoryCost { Id = 12, Name = "سرمایه گزاری", IsDeleted = false, IsPublic = true, UserId = 1 }
        );
        }
    }
}
