using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Medical_Appointment_System.Models;
using Smart_Medical_Appointment_System.Reposatories;

namespace Smart_Medical_Appointment_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGenericRepo<Doctor> doctorRepo;
        private readonly IGenericRepo<Patient> patientRepo;
        private readonly IGenericRepo<Appointment> appointmentRepo;

        public HomeController(
            IGenericRepo<Doctor> doctorRepo,
            IGenericRepo<Patient> patientRepo,
            IGenericRepo<Appointment> appointmentRepo)
        {
            this.doctorRepo = doctorRepo;
            this.patientRepo = patientRepo;
            this.appointmentRepo = appointmentRepo;
        }

        public IActionResult Index()
        {
            ViewBag.TotalDoctors = doctorRepo.GetAll().Count;
            ViewBag.TotalPatients = patientRepo.GetAll().Count;
            ViewBag.TotalAppointments = appointmentRepo.GetAll().Count;
            ViewBag.Pending = appointmentRepo.GetAll()
                                        .Count(a => a.Status == "Pending");
            ViewBag.Confirmed = appointmentRepo.GetAll()
                                        .Count(a => a.Status == "Confirmed");
            ViewBag.Completed = appointmentRepo.GetAll()
                                        .Count(a => a.Status == "Completed");
            ViewBag.Cancelled = appointmentRepo.GetAll()
                                        .Count(a => a.Status == "Cancelled");

       
            ViewBag.RecentAppointments = appointmentRepo.GetAll()
                                        .OrderByDescending(a => a.AppointmentDate)
                                        .Take(5)
                                        .ToList();
            return View();
        }
    }
}