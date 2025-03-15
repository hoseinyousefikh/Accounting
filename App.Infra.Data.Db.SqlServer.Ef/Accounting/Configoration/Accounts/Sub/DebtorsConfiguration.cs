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
    public class DebtorsConfiguration : IEntityTypeConfiguration<Debtors>
    {
        public void Configure(EntityTypeBuilder<Debtors> builder)
        {
            builder.ToTable("Debtors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Amount)
                .IsRequired().HasColumnType("decimal(18, 2)");


            builder.Property(d => d.Descriptions)
                .HasMaxLength(500);

            builder.HasOne(d => d.Users)
                .WithMany(d => d.Debtors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
