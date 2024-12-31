using System.ComponentModel.DataAnnotations;

namespace Sandogh.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }  // آی‌دی به عنوان کلید اصلی

        [Required(ErrorMessage = "وارد کردن کد ملی اجباری است")]
        [StringLength(10, ErrorMessage = "کد ملی باید ۱۰ رقم باشد")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید شامل ۱۰ رقم باشد")]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }  // کد ملی

        [Required(ErrorMessage = "وارد کردن نام کامل اجباری است")]
        [Display(Name = "نام کامل")]
        [MaxLength(100, ErrorMessage = "نام کامل نمی‌تواند بیش از ۱۰۰ کاراکتر باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره موبایل اجباری است")]
        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل باید با ۰۹ شروع شود و ۱۱ رقم باشد")]
        public string Mobile { get; set; }

        [Display(Name = "شماره تلفن ثابت")]
        [MaxLength(15, ErrorMessage = "شماره تلفن نمی‌تواند بیش از ۱۵ رقم باشد")]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "آدرس نمی‌تواند بیش از ۵۰۰ کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "تاریخ تولد")]
        [DataType(DataType.Date, ErrorMessage = "تاریخ تولد معتبر نیست")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "شماره شناسنامه")]
        [MaxLength(20, ErrorMessage = "شماره شناسنامه نمی‌تواند بیش از ۲۰ رقم باشد")]
        public string BirthCertificateNo { get; set; }

        [Display(Name = "نام پدر")]
        [MaxLength(100, ErrorMessage = "نام پدر نمی‌تواند بیش از ۱۰۰ کاراکتر باشد")]
        public string FatherName { get; set; }

        [Display(Name = "محل تولد")]
        [MaxLength(100, ErrorMessage = "محل تولد نمی‌تواند بیش از ۱۰۰ کاراکتر باشد")]
        public string BirthPlace { get; set; }

        [Display(Name = "شماره حساب")]
        [MaxLength(50, ErrorMessage = "شماره حساب نمی‌تواند بیش از ۵۰ رقم باشد")]
        public string AccountNumber { get; set; }

        public virtual List<Investment> Investment { get; set; }
        public Member()
        {
            Investment = new List<Investment>();
        }
    }
}
