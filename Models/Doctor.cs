using System.ComponentModel.DataAnnotations;

namespace Smart_Medical_Appointment_System.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        [Display(Name = "الاسم الكامل")]
        public string Name { get; set; }
        [Required(ErrorMessage = "التخصص مطلوب")]
        [Display(Name = "التخصص")]
        public string Specialization { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string? Phone { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
