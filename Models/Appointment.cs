using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Medical_Appointment_System.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "تاريخ الموعد مطلوب")]
        [Display(Name = "تاريخ الموعد")]
        public DateTime AppointmentDate {  get; set; }
        [Display(Name = "الحالة")]
        public string Status { get; set; } = "Pending";

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }
        [Required(ErrorMessage = "يجب اختيار دكتور")]
        public int DoctorId {  get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        [Required(ErrorMessage = "يجب اختيار مريض")]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

    }
}
