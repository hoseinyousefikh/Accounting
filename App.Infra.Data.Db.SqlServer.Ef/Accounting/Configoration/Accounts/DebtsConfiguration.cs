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
    public class DebtsConfiguration : IEntityTypeConfiguration<Debts>
    {
        public void Configure(EntityTypeBuilder<Debts> builder)
        {
            builder.ToTable("Debts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(d => d.AddDbts)
                .WithOne()
                .HasForeignKey(ad => ad.DebtsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Users)
                .WithMany(d => d.Debtses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
