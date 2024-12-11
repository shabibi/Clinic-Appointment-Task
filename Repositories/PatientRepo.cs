using ClinicAppointmentTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentTask.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //Add patirnt 
        public void AddPatient(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }

        }
        //Return All Patients data
        public IEnumerable<Patient> GetAllPatients()
        {
            try
            {
                return _context.Patients.Include(p => p.Appoinments).ToList();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Return patient data by patient's name 
        public Patient GetPatientByName(string paientName)
        {
            try
            {
                return _context.Patients.FirstOrDefault(p => p.PName == paientName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }


}
