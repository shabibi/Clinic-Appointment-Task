using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Services
{
    public interface IAppointmentService
    {
        void BookAppointment(string pname, string cname, DateTime appDate);
        IEnumerable<Appointment> GetAppointmentsByClinc(int cid);
        IEnumerable<Appointment> GetAppointmentsByPatient(int pid);
    }
}