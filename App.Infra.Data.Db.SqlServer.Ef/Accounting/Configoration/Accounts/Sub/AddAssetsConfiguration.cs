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
    public class AddAssetsConfiguration : IEntityTypeConfiguration<AddAssets>
    {
        public void Configure(EntityTypeBuilder<AddAssets> builder)
        {
            builder.ToTable("AddAssets");

            builder.HasKey(aa => aa.Id);

            builder.Property(aa => aa.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(aa => aa.Amount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)"); 


            builder.Property(aa => aa.Description)
                .HasMaxLength(500);

            builder.HasOne(aa => aa.Users)
                .WithMany(aa => aa.AddAssets)
                .HasForeignKey(aa => aa.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(aa => aa.Assets)
                   .WithMany(a => a.AddAsset)
                   .HasForeignKey(aa => aa.AssetsId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
