using ClinicAppointmentTask.Models;
using ClinicAppointmentTask.Repositories;

namespace ClinicAppointmentTask.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepo _clinicRepo;

        public ClinicService(IClinicRepo clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        // Adds a new clinic to the repository.
        public void AddClinic(Clinic clinic)
        {
            // Call the repository method to add the clinic to the database.
            _clinicRepo.AddClinic(clinic);
        }

        // Retrieves all clinics from the repository.
        public IEnumerable<Clinic> GetAllClinic()
        {
            // Call the repository method to get all clinics from the data source.
            return _clinicRepo.GetAllClinic().ToList();
        }

        // Retrieves a clinic based on its specialization.
        public Clinic GetClinictBySpecilization(string specilization)
        {
            // Call the repository method to get the clinic by specialization.
            return _clinicRepo.GetClinictBySpecilization(specilization);
        }

    }
}
