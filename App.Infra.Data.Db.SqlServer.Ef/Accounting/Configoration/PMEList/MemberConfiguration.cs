using App.Domain.Core.Accounting.Entities.PMEList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.PMEList
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(500);

            builder.Property(m => m.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(m => m.Users)
                .WithMany(m => m.Members)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
