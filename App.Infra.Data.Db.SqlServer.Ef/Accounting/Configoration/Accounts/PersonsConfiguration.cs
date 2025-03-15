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
    public class PersonsConfiguration : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PhonNumber)
                .IsRequired(false);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.HasOne(p => p.Contacts)
          .WithMany()
          .HasForeignKey(p => p.ContactsId);

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.IsPublic)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(p => p.Users)
                .WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}
