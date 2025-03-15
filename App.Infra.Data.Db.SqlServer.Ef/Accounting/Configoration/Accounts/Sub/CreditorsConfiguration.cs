using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Accounts.Sub
{
    public class CreditorsConfiguration : IEntityTypeConfiguration<Creditors>
    {
        public void Configure(EntityTypeBuilder<Creditors> builder)
        {
            builder.ToTable("Creditors");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Amount)
                .IsRequired().HasColumnType("decimal(18, 2)");


            builder.Property(c => c.Descriptions)
                .HasMaxLength(500);

            builder.HasOne(c => c.Users)
                .WithMany(c => c.Creditorses)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
