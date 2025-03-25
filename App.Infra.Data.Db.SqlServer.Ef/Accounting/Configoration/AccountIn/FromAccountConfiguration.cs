using App.Domain.Core.Accounting.Entities.AccountIn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.AccountIn
{
    public class FromAccountConfiguration : IEntityTypeConfiguration<FromAccount>
    {
        public void Configure(EntityTypeBuilder<FromAccount> builder)
        {
            builder.ToTable("FromAccounts");

            builder.HasKey(fa => fa.Id);

            builder.HasOne(fa => fa.Asset)
                .WithMany()
                .HasForeignKey(fa => fa.AssetsId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.Banks)
                .WithMany()
                .HasForeignKey(fa => fa.BankId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.Capitals)
                .WithMany()
                .HasForeignKey(fa => fa.CapitalId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.Debt)
                .WithMany()
                .HasForeignKey(fa => fa.DebtsId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.Fund)
                .WithMany()
                .HasForeignKey(fa => fa.FundsId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.Person)
                .WithMany()
                .HasForeignKey(fa => fa.PersonsId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.Creditors)
                .WithMany()
                .HasForeignKey(fa => fa.CreditorsId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fa => fa.SubcategoryIncomes)
                .WithMany()
                .HasForeignKey(fa => fa.SubCategoryIncomeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
