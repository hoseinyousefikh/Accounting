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
    public class AssetsConfiguration : IEntityTypeConfiguration<Assets>
    {
        public void Configure(EntityTypeBuilder<Assets> builder)
        {
            builder.ToTable("Assets");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(a => a.AddAsset)
                .WithOne()
                .HasForeignKey(aa => aa.AssetsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Users)
                .WithMany(a => a.Assetses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
