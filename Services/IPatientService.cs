using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Services
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientByName(string paientName);
    }
}