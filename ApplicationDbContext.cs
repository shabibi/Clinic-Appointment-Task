using ClinicAppointmentTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentTask
{
    public class ApplicationDbContext :DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Appointment> Appoinments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>()
                        .HasIndex(e => e.specilization)
                        .IsUnique();
            modelBuilder.Entity<Patient>()
                       .HasIndex(e => e.PName)
                       .IsUnique();
        }
    }
}
