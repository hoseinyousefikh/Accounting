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
    public class AddDbtsConfiguration : IEntityTypeConfiguration<AddDbts>
    {
        public void Configure(EntityTypeBuilder<AddDbts> builder)
        {
            builder.ToTable("AddDbts");

            builder.HasKey(ad => ad.Id);

            builder.Property(ad => ad.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ad => ad.Amount)
                .IsRequired().HasColumnType("decimal(18, 2)");


            builder.Property(ad => ad.Description)
                .HasMaxLength(500);

            builder.HasOne(ad => ad.Users)
               .WithMany(ad => ad.AddDbts)
               .HasForeignKey(ad => ad.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ad => ad.Debt)
                .WithMany(c => c.AddDbts)
                .HasForeignKey(ad => ad.DebtsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
