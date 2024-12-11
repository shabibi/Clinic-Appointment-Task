using ClinicAppointmentTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentTask.Repositories
{
    public class ClinicRepo : IClinicRepo
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Adds a new clinic to the database.
        public void AddClinic(Clinic clinic)
        {
            try
            {
                // Add the clinic entity to the DbSet
                _context.Clinic.Add(clinic);
                _context.SaveChanges();// Save changes to the database.
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }

        }

        // Retrieves all clinics from the database, including their related appointments.
        public IEnumerable<Clinic> GetAllClinic()
        {
            try
            {
                return _context.Clinic.Include(c => c.Appoinments).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        // Retrieves a clinic based on its specialization.
        public Clinic GetClinictBySpecilization(string specilization)
        {
            try
            {
                return _context.Clinic.FirstOrDefault(c => c.specilization == specilization);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }
}
