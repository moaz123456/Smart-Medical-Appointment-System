using Microsoft.AspNetCore.Mvc;

namespace Smart_Medical_Appointment_System.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
