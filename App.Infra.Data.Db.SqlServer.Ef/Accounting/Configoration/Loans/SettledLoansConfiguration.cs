using App.Domain.Core.Accounting.Entities.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Loans
{
    public class SettledLoansConfiguration : IEntityTypeConfiguration<SettledLoans>
    {
        public void Configure(EntityTypeBuilder<SettledLoans> builder)
        {
            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.Name)
                .IsRequired();

            builder.Property(sl => sl.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sl => sl.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(sl => sl.Description)
                .HasMaxLength(500);

            builder.HasOne(sl => sl.Users)
                .WithMany(u => u.SettledLoans)
                .HasForeignKey(sl => sl.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
