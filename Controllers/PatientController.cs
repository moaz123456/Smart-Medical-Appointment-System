using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Medical_Appointment_System.Models;
using Smart_Medical_Appointment_System.Reposatories;
using System.Net.NetworkInformation;

namespace Smart_Medical_Appointment_System.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IGenericRepo<Patient> patientRepo;

        public PatientController(IGenericRepo<Patient> patientRepo)
        {
            this.patientRepo = patientRepo;
        }
        public IActionResult Index()
        {
            return View("Index",patientRepo.GetAll());
        }
        public IActionResult Details(int id)
        {
            var doctor = patientRepo.GetById(id);
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientRepo.Add(patient);
                patientRepo.Save();
                return RedirectToAction("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = patientRepo.GetById(id);
            if (patient == null)
                return NotFound();
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientRepo.Update(patient);
                patientRepo.Save();
                return RedirectToAction("Index");
            }
            return View(patient);

        }
        public IActionResult Delete(int id)
        {
            var patient = patientRepo.GetById(id);
            if (patient == null)
                return NotFound();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = patientRepo.GetById(id);
            if (patient == null)
                return NotFound();
            patientRepo.Delete(patient);
            patientRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
