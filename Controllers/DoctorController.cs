using Microsoft.AspNetCore.Mvc;
using Smart_Medical_Appointment_System.Models;
using Smart_Medical_Appointment_System.Reposatories;

namespace Smart_Medical_Appointment_System.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IGenericRepo<Doctor> doctorRepo;

        public DoctorController(IGenericRepo<Doctor> doctorRepo)
        {
            this.doctorRepo = doctorRepo;
        }
        public IActionResult Index()
        {
            return View("Index",doctorRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            var doctor = doctorRepo.GetById(id);
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
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctorRepo.Add(doctor);
                doctorRepo.Save();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doctor = doctorRepo.GetById(id);
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctorRepo.Update(doctor);
                doctorRepo.Save();
                return RedirectToAction("Index");
            }
            return View(doctor);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctor = doctorRepo.GetById(id);
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = doctorRepo.GetById(id);
            if (doctor == null)
                return NotFound();
            doctorRepo.Delete(doctor);
            doctorRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
