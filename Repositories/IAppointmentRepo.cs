using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Repositories
{
    public interface IAppointmentRepo
    {
        void BookAppointment(Appointment appointment);
        IEnumerable<Appointment> GetAppointmentsByClinc(int cid);
        IEnumerable<Appointment> GetAppointmentsByPatient(int pid);
    }
}