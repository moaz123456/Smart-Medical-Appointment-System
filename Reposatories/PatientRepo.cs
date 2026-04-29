using Microsoft.EntityFrameworkCore;
using Smart_Medical_Appointment_System.Models;

namespace Smart_Medical_Appointment_System.Reposatories
{
    public class PatientRepo : IGenericRepo<Patient>
    {
        private readonly AppDbContext context;

        public PatientRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<Patient> GetAll()
        {
            return context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            var pat =  context.Patients.FirstOrDefault(p => p.Id == id);
            return pat;
        }

        public void Add(Patient patient)
        {
            context.Add(patient);
        }

        public void Update(Patient patient)
        {
            context.Update(patient);
        }

        public void Delete(Patient patient)
        {
            var pat = context.Patients.Find(patient.Id);
            if (pat != null)
            {
                context.Patients.Remove(pat);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
