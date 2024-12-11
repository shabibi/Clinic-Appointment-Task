using ClinicAppointmentTask.Models;
using ClinicAppointmentTask.Repositories;

namespace ClinicAppointmentTask.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;
        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public void AddPatient(Patient patient)
        {
            // Add the patient to the repository
            _patientRepo.AddPatient(patient);
        }
        public IEnumerable<Patient> GetAllPatients()
        {
            // Return all patients from the repository
            return _patientRepo.GetAllPatients().ToList();
        }

        public Patient GetPatientByName(string paientName)
        {
            // Return  patient from the repository 
            return _patientRepo.GetPatientByName(paientName);
        }
    }
}
