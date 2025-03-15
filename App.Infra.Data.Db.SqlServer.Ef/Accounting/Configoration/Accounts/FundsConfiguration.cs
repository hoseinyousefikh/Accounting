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
    public class FundsConfiguration : IEntityTypeConfiguration<Funds>
    {
        public void Configure(EntityTypeBuilder<Funds> builder)
        {
            builder.ToTable("Funds");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);



            builder.HasOne(f => f.Users)
                .WithMany(f =>f.Fundses)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
              new Funds { Id = 1, Name = "کیف پول", IsDeleted = false, IsPublic = true, UserId = 1 },
              new Funds { Id = 2, Name = "گاو صندوق", IsDeleted = false, IsPublic = true, UserId = 1 },
              new Funds { Id = 3, Name = " منزل", IsDeleted = false, IsPublic = true, UserId = 1 }

          );
        }
    }
}
