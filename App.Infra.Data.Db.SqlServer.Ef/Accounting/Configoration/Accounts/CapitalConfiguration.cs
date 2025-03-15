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
    public class CapitalConfiguration : IEntityTypeConfiguration<Capital>
    {
        public void Configure(EntityTypeBuilder<Capital> builder)
        {
            builder.ToTable("Capitals");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.AddCapital)
                .WithOne()
                .HasForeignKey(ac => ac.CapitalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Users)
                .WithMany(c => c.Capitals)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
