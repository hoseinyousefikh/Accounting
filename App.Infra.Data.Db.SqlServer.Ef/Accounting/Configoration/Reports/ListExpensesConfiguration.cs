using App.Domain.Core.Accounting.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Reports
{
    public class ListExpensesConfiguration : IEntityTypeConfiguration<ListExpenses>
    {
        public void Configure(EntityTypeBuilder<ListExpenses> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.DueDate)
                .IsRequired();

            builder.Property(e => e.CheckNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(e => e.PaymentType)
                .IsRequired()
                .HasConversion<int>(); 

            builder.HasOne(e => e.Banks)
                .WithMany()
                .HasForeignKey(e => e.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Users)
                .WithMany(e => e.ListExpenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
