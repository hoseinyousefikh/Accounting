using App.Domain.Core.Accounting.Entities.Budgetings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Budgetings
{
    public class BudgetingConfiguration : IEntityTypeConfiguration<Budgeting>
    {
        public void Configure(EntityTypeBuilder<Budgeting> builder)
        {
            builder.ToTable("Budgetings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.MinAmount).IsRequired().HasColumnType("decimal(18, 2)");

            builder.Property(b => b.MaxAmount).IsRequired().HasColumnType("decimal(18, 2)");

            builder.Property(b => b.FDate).IsRequired();
            builder.Property(b => b.TDate).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();

            builder.HasOne(b => b.Users)
                .WithMany(u => u.Budgetings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
