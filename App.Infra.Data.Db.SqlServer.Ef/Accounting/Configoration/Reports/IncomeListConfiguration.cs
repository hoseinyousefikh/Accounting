using App.Domain.Core.Accounting.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Reports
{
    public class IncomeListConfiguration : IEntityTypeConfiguration<IncomeList>
    {
        public void Configure(EntityTypeBuilder<IncomeList> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Date)
                .IsRequired();

            builder.Property(i => i.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.DueDate)
                .IsRequired();

            builder.Property(i => i.CheckNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(i => i.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(i => i.PaymentType)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(i => i.Banks)
                .WithMany()
                .HasForeignKey(i => i.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Users)
                .WithMany(i => i.IncomeLists)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
