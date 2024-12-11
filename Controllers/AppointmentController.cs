using ClinicAppointmentTask.Models;
using ClinicAppointmentTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentTask.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AppointmentController :ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // Retrieves all appointments for a specific patient by their ID.
        [HttpGet("Get All Appointments By Patient Id")]
        public IActionResult GetAppointmentsByPatient(int pid)
        {
            try
            {
                // Call the service to fetch appointments for the specified patient.
                var appointments = _appointmentService.GetAppointmentsByPatient(pid);
                if (appointments.Count() == 0)// Check if no appointments were found
                {
                    return NotFound("No Appointment found.");
                }

                // Return the appointments in the response.
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response if there is an exception
                return StatusCode(500, $"An error occurred while retrieving appointments. {(ex.Message)}");
            }
        }

        // Retrieves all appointments for a specific clinic by their ID.
        [HttpGet("Get All Appointments By Clinic Id")]
        public IActionResult GetAppointmentsByClinc(int cid)
        {
            try
            {
                // Call the service to fetch appointments for the specified clinic.
                var appointments = _appointmentService.GetAppointmentsByClinc(cid);

                if (appointments.Count() <= 0)// Check if no appointments were found
                {
                    return NotFound("No Appointment found.");
                }
                // Return the appointments in the response.
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response if there is an exception
                return StatusCode(500, $"An error occurred while retrieving appointments. {(ex.Message)}");
            }
        }

        [HttpPost("Book Appintment")]
        public IActionResult BookAppointment(string patientName, string ClinicName, DateTime Date)
        {
            try
            {
                // Call the service to book the appointment
                _appointmentService.BookAppointment(patientName, ClinicName, Date);
                return Created();
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response if there is an exception
                return StatusCode(500, $"An error occurred while booking appointments. {(ex.Message)}");
            }
        }

    }
}
