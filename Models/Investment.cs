using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sandogh.Models
{
    public class Investment
    {
        [Key]
        public int Id { get; set; }

        public int MemberId { get; set; }  // آی‌دی به عنوان کلید اصلی

        [Display(Name = "مبلغ سرمایه")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }  // استفاده از decimal برای دقت بالاتر

        [Display(Name = "نوع سرمایه‌گذاری")]
        public string InvestmentType { get; set; } = "سپرده بلندمدت"; // پیش‌فرض برای ایران

        [Display(Name = "نرخ سود")]
        public double InterestRate { get; set; }

        [Display(Name = "تاریخ شروع")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "وضعیت")]
        public string Status { get; set; } = "فعال";

        [Display(Name = "توضیحات")]
        public string? Note { get; set; }

        public virtual Member? Member { get; set; }

    }
}
