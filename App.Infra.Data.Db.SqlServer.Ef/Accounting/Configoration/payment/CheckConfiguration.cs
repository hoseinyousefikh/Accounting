using App.Domain.Core.Accounting.Entities.payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.payment
{
    public class CheckConfiguration : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ChecNumber)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(c => c.Amount)
                .IsRequired().HasColumnType("decimal(18, 2)");


            builder.Property(c => c.Description)
                .HasMaxLength(500); 

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(c => c.Banks)
                .WithMany() 
                .HasForeignKey(c => c.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.SubCategorise)
                .WithMany()
                .HasForeignKey(c => c.SubcategoryCostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.SubCategoryIncomes)
                .WithMany()
                .HasForeignKey(c => c.SubcategoryIncomeId)
                .OnDelete(DeleteBehavior.SetNull); 

            builder.HasOne(c => c.Members)
                .WithMany()
                .HasForeignKey(c => c.MemderId)
                .OnDelete(DeleteBehavior.NoAction);  

            builder.HasOne(c => c.Events)
                .WithMany()
                .HasForeignKey(c => c.EventId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(c => c.Projects)
                .WithMany()
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Users)
                .WithMany(u => u.Checks)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
