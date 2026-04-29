using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Smart_Medical_Appointment_System.Models;

namespace Smart_Medical_Appointment_System.Reposatories
{
    public class DoctorRepo: IGenericRepo<Doctor>
    {
        AppDbContext context;
        public DoctorRepo(AppDbContext context) {
            this.context = context;
        }

        public List<Doctor> GetAll() {
            var docs = context.Doctors.ToList();
            return docs;
        }
        public Doctor GetById(int id) {
            var doc = context.Doctors.AsNoTracking().Include(d => d.Appointments).FirstOrDefault(d => d.Id == id);
            return doc;
        }

        public void Delete(Doctor entity)
        {
            context.Set<Doctor>().Remove(entity);
        }
        public void Update(Doctor doctor)
        {
            context.Update(doctor);
        }
        public void Add(Doctor doctor)
        {
            context.Add(doctor);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
