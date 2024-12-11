using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Services
{
    public interface IClinicService
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinic();
        Clinic GetClinictBySpecilization(string specilization);
    }
}