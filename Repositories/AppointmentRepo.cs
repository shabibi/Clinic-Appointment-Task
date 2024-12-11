using ClinicAppointmentTask.Models;

namespace ClinicAppointmentTask.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        //view appoinment by clinic id
        public IEnumerable<Appointment> GetAppointmentsByClinc(int cid)
        {
            try
            {
                return _context.Appoinments.Where(a => a.CID == cid).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }

        }
        //view appoinment by patient id 
        public IEnumerable<Appointment> GetAppointmentsByPatient(int pid)
        {
            try
            {
                return _context.Appoinments.Where(a => a.PID == pid).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        // Books an appointment by adding it to the database.
        public void BookAppointment(Appointment appointment)
        {
            try
            {
                _context.Add(appointment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }
}

