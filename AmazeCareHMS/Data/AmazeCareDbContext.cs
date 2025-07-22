using Microsoft.EntityFrameworkCore;
using AmazeCareHMS.Models;

namespace AmazeCareHMS.Data
{
    public class AmazeCareDbContext : DbContext
    {
        public AmazeCareDbContext(DbContextOptions<AmazeCareDbContext> options)
            : base(options)
        {
        }

        // DbSets for each model
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ↔ Patient (1-to-1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User ↔ Doctor (1-to-1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Appointment ↔ Patient (many-to-1)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict); // avoid cascade path issues

            // Appointment ↔ Doctor (many-to-1)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Consultation ↔ Appointment (1-to-1)
            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Appointment)
                .WithOne(a => a.Consultation)
                .HasForeignKey<Consultation>(c => c.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Prescription ↔ Consultation (many-to-1)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Consultation)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(p => p.ConsultationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
