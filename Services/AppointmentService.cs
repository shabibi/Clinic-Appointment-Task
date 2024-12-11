using ClinicAppointmentTask.Models;
using ClinicAppointmentTask.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicAppointmentTask.Services
{
    public class AppointmentService : IAppointmentService
    {
        // Private fields to hold the injected dependencies
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IPatientService _patientService;
        private readonly IClinicService _clinicalService;

        // Constructor to initialize the AppointmentService with required dependencies.
        public AppointmentService(IAppointmentRepo appointmentRepo, IPatientService patientService, IClinicService clinicService)
        {
            _appointmentRepo = appointmentRepo;
            _patientService = patientService;
            _clinicalService = clinicService;
        }

        // Retrieves all appointments for a specific clinic based on the clinic ID.
        public IEnumerable<Appointment> GetAppointmentsByClinc(int cid)
        {
            return _appointmentRepo.GetAppointmentsByClinc(cid);
        }

        // Retrieves all appointments for a specific clinic based on the Patient ID.
        public IEnumerable<Appointment> GetAppointmentsByPatient(int pid)
        {
            return _appointmentRepo.GetAppointmentsByPatient(pid);
        }

        // Books an appointment for a patient in a specific clinic on a specified date.
        public void BookAppointment(string pname, string cname, DateTime appDate)
        {
            int slotNum = 0; // The slot number to be assigned for the new appointment.
            int ReservedSlots = 0; // Counter for slots already reserved on the given date.

            // Retrieve the patient by name.
            Patient patient = _patientService.GetPatientByName(pname);

            if (patient == null)
                throw new InvalidOperationException("Invalid paitent name.");

            // Retrieve the clinic by specialization.
            Clinic clinic = _clinicalService.GetClinictBySpecilization(cname);

            if (clinic == null)
                throw new InvalidOperationException("Invalid clinc name.");

            // Retrieve all appointments for the clinic.
            var appointments = GetAppointmentsByClinc(clinic.CID);

            // Iterate over the clinic's appointments to check for conflicts and count reserved slots.
            foreach (var appointment in appointments)
            {
                if (appointment.date == appDate)
                {
                    ReservedSlots++;

                    // Check if the patient already has an appointment on the same date.
                    if (appointment.PID == patient.PID)
                        throw new InvalidOperationException("Patient have appointment in this day.");
                }
            }

            // Calculate the slot number for the new appointment.
            slotNum = ReservedSlots + 1;

            //Check if the clinic has available slots for the given date.
            if (slotNum > clinic.NumberOfSlots)
                throw new InvalidOperationException("NO appointment available on this day.");

            // Create a new appointment and set its details.
            var newAppointment = new Appointment
            {
                CID = clinic.CID,
                PID = patient.PID,
                SlotNumber = slotNum,
                date = appDate
            };

            // Add the new appointment to the database using the repository.
            _appointmentRepo.BookAppointment(newAppointment);
        }

    }
}
