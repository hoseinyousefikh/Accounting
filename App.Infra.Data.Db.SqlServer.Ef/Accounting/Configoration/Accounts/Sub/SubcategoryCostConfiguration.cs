using App.Domain.Core.Accounting.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.Accounts.Sub
{
    public class SubcategoryCostConfiguration : IEntityTypeConfiguration<SubcategoryCost>
    {
        public void Configure(EntityTypeBuilder<SubcategoryCost> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sc => sc.IsDeleted)
                .IsRequired();
            builder.Property(sc => sc.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(sc => sc.IsPublic)
                .HasDefaultValue(true);

          
            builder.HasOne(sc => sc.CategoryCostes)
                .WithMany(c => c.SubcategoryCosts)
                .HasForeignKey(sc => sc.CategoryCostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(ad => ad.Amount)
               .IsRequired().HasColumnType("decimal(18, 2)");

            builder.HasOne(si => si.Users)
                .WithMany(si => si.SubcategoryCosts)
                .HasForeignKey(si => si.UserId)
                .OnDelete(DeleteBehavior.NoAction);
     builder.HasData(
     // For Category "اغذیه"
     new SubcategoryCost { Id = 1, Name = "تنقلات", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000},
     new SubcategoryCost { Id = 2, Name = "گوشت قرمز", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 3, Name = "مرغ", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 4, Name = "ماهی و میگو", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 5, Name = "برنج", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 6, Name = "نان", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 7, Name = "لبنیات", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 8, Name = "نوشیدنی", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 9, Name = "حبوبات", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 10, Name = "غلات", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 11, Name = "میوه و تره بار", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 12, Name = "غذای بیرون", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 13, Name = "رستوران", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 14, Name = "کافی شاپ", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 15, Name = "سایر", CategoryCostId = 1, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "مسکن"
     new SubcategoryCost { Id = 16, Name = "قبض اب", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 17, Name = "قبض برق", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 18, Name = "قبض گاز", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 19, Name = "قبض تلفن", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 20, Name = "شارژ ساختمان", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 21, Name = "اجاره منزل", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 22, Name = "لوازم منزل", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 23, Name = "قبض شارژ موبایل", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 24, Name = "بیمه ساختمان", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 25, Name = "تعمیرات ساختمان", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 26, Name = "عوارض شهرداری", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 27, Name = "مالیات", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 28, Name = "سایر", CategoryCostId = 2, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "البسه و پوشاک"
     new SubcategoryCost { Id = 29, Name = "خیاطی", CategoryCostId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 30, Name = "خرید پوشاک", CategoryCostId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 31, Name = "خشکشویی", CategoryCostId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 32, Name = "سایر", CategoryCostId = 3, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "خودرو"
     new SubcategoryCost { Id = 33, Name = "بنزین", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 34, Name = "تعویض روغن", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 35, Name = "جرایم رانندگی", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 36, Name = "طرح ترافیک", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 37, Name = "پارکینگ", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 38, Name = "بیمه ثالث", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 39, Name = "بیمه بدنه", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 40, Name = "تغییرات اساسی", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 41, Name = "عوارض خودرو", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 42, Name = "سایر", CategoryCostId = 4, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "ایاب و ذهاب مسافرت"
     new SubcategoryCost { Id = 43, Name = "کرایه اژانس", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 44, Name = "کرایه تاکسی", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 45, Name = "کرایه اتوبوس", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 46, Name = "کرایه مترو", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 47, Name = "سرویس", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 48, Name = "بلیط قطار", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 49, Name = "بلیط هواپیما", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 50, Name = "بلیط اتوبوس", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 51, Name = "کرایه هتل و محل اقامت", CategoryCostId = 5, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "آموزش و تحصیلات"
     new SubcategoryCost { Id = 52, Name = "کلاس های ورزشی", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 53, Name = "شهریه مدرسه", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 54, Name = "شهریه دانشگاه", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 55, Name = "شهریه مهد کودک", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 56, Name = "لوازم التحریر", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 57, Name = "کلاس های آموزش", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 58, Name = "سایر", CategoryCostId = 6, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "فرهنگی و سرگرمی"
     new SubcategoryCost { Id = 59, Name = "نرم افزار", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 60, Name = "کتاب", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 61, Name = "روزنامه و مجله", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 62, Name = "فیلم", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 63, Name = "سینما", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 64, Name = "موسیقی", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 65, Name = "تیاتر", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 66, Name = "کنسرت", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 67, Name = "اینترنت", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 68, Name = "بازی و سرگرمی", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 69, Name = "اماكن فرهنگی", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 70, Name = "سایر", CategoryCostId = 7, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "هدایا"
     new SubcategoryCost { Id = 71, Name = "سوغات", CategoryCostId = 8, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 72, Name = "فرهنگی", CategoryCostId = 8, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 73, Name = "لوازم", CategoryCostId = 8, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 74, Name = "سایر", CategoryCostId = 8, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "بهداشتی درمانی"
     new SubcategoryCost { Id = 75, Name = "ویزیت پزشک", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 76, Name = "لوازم بهداشتی", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 77, Name = "لوازم ارایشی", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 78, Name = "لوازم پزشکی", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 79, Name = "دندان پزشکی", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 80, Name = "جراحی", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 81, Name = "بستری", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 82, Name = "آزمایشگاه", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 83, Name = "تصویر برداری", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 84, Name = "دارو", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 85, Name = "بیمه ها", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 86, Name = "سایر", CategoryCostId = 9, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     // For Category "هزینه های اداری"
     new SubcategoryCost { Id = 87, Name = "هزینه های تشکیل پرونده", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 88, Name = "هزینه دادرسی", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 89, Name = "هزینه پست", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 90, Name = "هزینه مشاور", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 91, Name = "هزینه دعاوی", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 92, Name = "هزینه ثبت نام در کارگاه", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 93, Name = "سایر", CategoryCostId = 10, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 94, Name = "زکات", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 95, Name = "خمس", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 96, Name = "صدقه", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 97, Name = "کفاره", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 98, Name = "نذری", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 99, Name = "وقف", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 100, Name = "سایر دیون اسلامی", CategoryCostId = 11, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },

     new SubcategoryCost { Id = 101, Name = "سهام", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 102, Name = "اوراق قرضه", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 103, Name = "سرمایه گذاری در املاک", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 104, Name = "سرمایه گذاری در ارز", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 105, Name = "سرمایه گذاری در طلا", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 106, Name = "سرمایه گذاری در کریپتوکارنسی", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 107, Name = "سرمایه گذاری در صندوق های سرمایه گذاری", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 },
     new SubcategoryCost { Id = 108, Name = "سایر سرمایه گذاری ها", CategoryCostId = 12, IsDeleted = false, IsPublic = true, UserId = 1, Amount = 10000000 }


   );
        }
    }
}
