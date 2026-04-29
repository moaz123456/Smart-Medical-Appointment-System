using System.ComponentModel.DataAnnotations;

namespace Smart_Medical_Appointment_System.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        [Display(Name = "الاسم الكامل")]
        public string Name { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
        [Display(Name = "البريد الإلكتروني")]
        public string? Email { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
