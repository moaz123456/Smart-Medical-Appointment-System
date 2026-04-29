using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Medical_Appointment_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Smart_Medical_Appointment_System
{
    public class _ِAppDbContextcs : IdentityDbContext<IdentityUser>
    {
       public DbSet<Doctor> Doctors { get; set; }
       public DbSet<Patient> Patients { get; set; }
       public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
               .HasOne(a => a.Doctor)
               .WithMany(d => d.Appointments)
               .HasForeignKey(a => a.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
