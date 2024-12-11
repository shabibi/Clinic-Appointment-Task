using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Repositories
{
    public interface IClinicRepo
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinic();
        Clinic GetClinictBySpecilization(string specilization);
    }
}