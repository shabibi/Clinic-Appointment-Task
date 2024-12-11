using ClinicAppointmentTask.Models;
using ClinicAppointmentTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentTask.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("Add Patient")]
        public IActionResult AddPatient(string patientName, int Age, Gender gender)
        {
            try
            {
                // Check if patientName is null
                if (patientName == null)
                {
                    return BadRequest("Patient name is required");
                }
                // Validate the ModelState
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // Create a new patient 
                var patient = new Patient
                {
                    PName = patientName,
                    age = Age,
                    gender = gender
                };
                // Call the service to add the patient
                _patientService.AddPatient(patient);

                // Return a success response with the created patient's details
                return CreatedAtAction(nameof(AddPatient), new { id = patient.PID }, patient);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while adding the patient. {ex.Message} ");
            }

        }

        [HttpGet("Get All Patients")]
        public IActionResult GetAllPatients()
        {
            try
            {
                // get all patients from the service
                var patients = _patientService.GetAllPatients();

                // Check if the result is empty
                if (patients == null)
                {
                    return NotFound("No patients found.");
                }

                // Return the list of patients
                return Ok(patients);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500,$"An error occurred while retrieving patients. { (ex.Message)}");

            }
        }

    }
}
