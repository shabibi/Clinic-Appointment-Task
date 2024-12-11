using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Repositories
{
    public interface IPatientRepo
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientByName(string paientName);
    }
}