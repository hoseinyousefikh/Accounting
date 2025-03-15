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
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Banks");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Oranches)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.AccountNumber)
                .IsRequired();

            builder.Property(b => b.CardNumber)
                .IsRequired();

            builder.Property(b => b.ShabaNumber)
                .IsRequired();

            builder.Property(b => b.Amount)
                .IsRequired().HasColumnType("decimal(18, 2)");


            builder.HasOne(b => b.Users)
                .WithMany(b => b.Banks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
