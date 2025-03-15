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
    public class AddCapitalConfiguration : IEntityTypeConfiguration<AddCapital>
    {
        public void Configure(EntityTypeBuilder<AddCapital> builder)
        {
            builder.ToTable("AddCapitals");

            builder.HasKey(ac => ac.Id);

            builder.Property(ac => ac.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ac => ac.Amount)
                .IsRequired().HasColumnType("decimal(18, 2)");


            builder.Property(ac => ac.Description)
                .HasMaxLength(500);
            builder.HasOne(ac => ac.Users)
               .WithMany(ac => ac.AddCapitals)
               .HasForeignKey(ac => ac.UserId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(ac => ac.Capitals)
                .WithMany(c => c.AddCapital)
                .HasForeignKey(ac => ac.CapitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
