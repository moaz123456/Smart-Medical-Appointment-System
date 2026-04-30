using Microsoft.EntityFrameworkCore;
using Smart_Medical_Appointment_System.Models;
namespace Smart_Medical_Appointment_System.Reposatories
{
    public class AppointmentRepo:IGenericRepo<Appointment>
    {
        private readonly AppDbContext context;
        public AppointmentRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<Appointment> GetAll() { 
             var Apps = context.Appointments
                           .Include(a => a.Doctor)
                           .Include(a => a.Patient).ToList();
             return Apps;
        }
        public Appointment GetById(int id)
        {
            var app = context.Appointments
                .AsNoTracking()
                .Include(a=>a.Doctor)
                .Include(a=>a.Patient)
                .FirstOrDefault(x => x.Id == id);
            return app;
        }
        public void Add(Appointment appointment)
        {
            context.Add(appointment);
        }

        public void Update(Appointment appointment) { 
            context.Update(appointment);
        }

        public void Delete(Appointment appointment)
        {
            context.Remove(appointment);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
