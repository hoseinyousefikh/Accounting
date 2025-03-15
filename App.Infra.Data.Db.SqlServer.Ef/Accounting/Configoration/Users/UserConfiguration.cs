using App.Domain.Core.Accounting.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace App.Infra.Data.Db.SqlServer.Ef.Accounting.Configoration.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);

            builder.Property(u => u.IsBloked)
                .HasDefaultValue(false);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);

            builder.HasMany(u => u.Contacts)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.IncomeLists)
                .WithOne(il => il.Users)
                .HasForeignKey(il => il.UserId);

            builder.HasMany(u => u.ListExpenses)
                .WithOne(le => le.Users)
                .HasForeignKey(le => le.UserId);

            builder.HasMany(u => u.Events)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.UserId);

            builder.HasMany(u => u.Members)
                .WithOne(m => m.Users)
                .HasForeignKey(m => m.UserId);

            builder.HasMany(u => u.Projects)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.Checks)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.Criticisms)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.SettledLoans)
                .WithOne(sl => sl.Users)
                .HasForeignKey(sl => sl.UserId);

            builder.HasMany(u => u.Budgetings)
                .WithOne(b => b.Users)
                .HasForeignKey(b => b.UserId);

            builder.HasMany(u => u.SubcategoryCosts)
                .WithOne(sc => sc.Users)
                .HasForeignKey(sc => sc.UserId);

            builder.HasMany(u => u.SubcategoryIncomes)
                .WithOne(si => si.Users)
                .HasForeignKey(si => si.UserId);

            builder.HasMany(u => u.Debtors)
                .WithOne(d => d.Users)
                .HasForeignKey(d => d.UserId);

            builder.HasMany(u => u.Creditorses)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.AddDbts)
                .WithOne(ad => ad.Users)
                .HasForeignKey(ad => ad.UserId);

            builder.HasMany(u => u.AddCapitals)
                .WithOne(ac => ac.Users)
                .HasForeignKey(ac => ac.UserId);

            builder.HasMany(u => u.AddAssets)
                .WithOne(aa => aa.Users)
                .HasForeignKey(aa => aa.UserId);

            builder.HasMany(u => u.Assetses)
                .WithOne(a => a.Users)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(u => u.Banks)
                .WithOne(b => b.Users)
                .HasForeignKey(b => b.UserId);

            builder.HasMany(u => u.Capitals)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(u => u.CategoryCosts)
                .WithOne(cc => cc.Users)
                .HasForeignKey(cc => cc.UserId);

            builder.HasMany(u => u.CategoryIncomes)
                .WithOne(ci => ci.Users)
                .HasForeignKey(ci => ci.UserId);

            builder.HasMany(u => u.Debtses)
                .WithOne(d => d.Users)
                .HasForeignKey(d => d.UserId);

            builder.HasMany(u => u.Fundses)
                .WithOne(f => f.Users)
                .HasForeignKey(f => f.UserId);

            builder.HasMany(u => u.Persons)
                .WithOne(p => p.Users)
                .HasForeignKey(p => p.UserId);
            var hasher = new PasswordHasher<User>();


            var admin = new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                IsActive = true,
                RoleId = 1,

            };
            admin.PasswordHash = hasher.HashPassword(admin, "H1h2h3h4@");

            var employee = new User
            {
                Id = 2,
                FirstName = "Employee",
                LastName = "User",
                UserName = "employee",
                NormalizedUserName = "EMPLOYEE",
                Email = "employee@example.com",
                NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                EmailConfirmed = true,
                PhoneNumber = "0987654321",
                IsActive = true,
                RoleId = 2,

            };
            employee.PasswordHash = hasher.HashPassword(employee, "H1h2h3h4@");


            builder.HasData(admin, employee);
        }
    }
}

