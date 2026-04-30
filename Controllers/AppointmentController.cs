using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart_Medical_Appointment_System.Models;
using Smart_Medical_Appointment_System.Reposatories;
using System.Runtime.InteropServices;
namespace Smart_Medical_Appointment_System.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IGenericRepo<Appointment> appointmentRepo;
        private readonly IGenericRepo<Doctor> doctorRepo;
        private readonly IGenericRepo<Patient> patientRepo;

        public AppointmentController(
            IGenericRepo<Appointment> appointmentRepo,
            IGenericRepo<Doctor> doctorRepo,
            IGenericRepo<Patient> patientRepo)
        {
            this.appointmentRepo = appointmentRepo;
            this.doctorRepo = doctorRepo;
            this.patientRepo = patientRepo;
        }
        public IActionResult Index()
        {
            return View(appointmentRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            var app = appointmentRepo.GetById(id);
            if (app == null)
            {
                return NotFound();
            }
            return View(app);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointmentRepo.Add(appointment);
                appointmentRepo.Save();
                return RedirectToAction("Index");
            }
            LoadDropdowns();
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = appointmentRepo.GetById(id);
            if (appointment == null)
                return NotFound();
            LoadDropdowns();
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointmentRepo.Update(appointment);
                appointmentRepo.Save();
                return RedirectToAction("Index");
            }
            LoadDropdowns();
            return View(appointment);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointment = appointmentRepo.GetById(id);
            if (appointment == null)
                return NotFound();
            LoadDropdowns();
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = appointmentRepo.GetById(id);
            if (appointment == null)
                return NotFound();

            appointmentRepo.Delete(appointment);
            appointmentRepo.Save();
            return RedirectToAction("Index");
        }

        private void LoadDropdowns()
        {
            ViewBag.Doctors = new SelectList(
                doctorRepo.GetAll(), "Id", "Name");
            ViewBag.Patients = new SelectList(
                patientRepo.GetAll(), "Id", "Name");
            ViewBag.Statuses = new SelectList(new[]
            {
                "Pending", "Confirmed", "Cancelled", "Completed"
            });

        }
    }
}
