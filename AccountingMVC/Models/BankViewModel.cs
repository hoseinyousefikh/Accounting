using System.ComponentModel.DataAnnotations;

namespace AccountingMVC.Models
{
    public class BankViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام بانک الزامی است")]
        [MaxLength(100, ErrorMessage = "نام بانک نمی‌تواند بیشتر از 100 کاراکتر باشد")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "لطفاً نام شعبه را وارد کنید")]
        public string Oranches { get; set; }

        [Required(ErrorMessage = "لطفاً شماره حساب را وارد کنید")]
        [Range(10000000, 9999999999, ErrorMessage = "شماره حساب باید بین 8 تا 10 رقم باشد")]
        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "لطفاً شماره کارت را وارد کنید")]
        [Range(1000000000000000, 9999999999999999, ErrorMessage = "شماره کارت باید 16 رقم باشد")]
        public long CardNumber { get; set; }

        [Required(ErrorMessage = "لطفاً شماره شبا را وارد کنید")]
        [Range(100000000000000000, 999999999999999999, ErrorMessage = "شماره شبا باید 18 رقم باشد")]
        public long ShabaNumber { get; set; }

        [Range(0.01, 100000000000.00, ErrorMessage = "مبلغ باید بین 0.01 و 100,000,000,000 باشد")]
        public decimal Amount { get; set; }

        public bool IsPublic { get; set; }

        public int UserId { get; set; }
    }
}
