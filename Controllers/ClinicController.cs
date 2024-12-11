using ClinicAppointmentTask.Models;
using ClinicAppointmentTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentTask.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        // Adds a new clinic to the system.
        [HttpPost("Add Clinic")]
        public IActionResult AddClinic(string specilization, int numberOfSlots)
        {
            try
            {
                // Check if the specialization is provided
                if (specilization == null)
                {
                    // Return a bad request response if the specialization is missing
                    return BadRequest("Clinic data is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // Create a new Clinic object using the provided values
                var clinic = new Clinic
                {
                    specilization = specilization,
                    NumberOfSlots = numberOfSlots
                };
                // Call the service layer to add the clinic to the repository/database
                _clinicService.AddClinic(clinic);
                return CreatedAtAction(nameof(AddClinic), new { id = clinic.CID }, clinic);
            }
            catch (Exception ex)
            {
                // Return a 500 internal server error response if something goes wrong
                return StatusCode(500, $"An error occurred while adding the clinic. {ex.Message} ");
            }

        }

        [HttpGet("Get All Clincs")]
        // Retrieves all clinics from the system.
        public IActionResult GetAllClinic()
        {
            try
            {
                // Retrieve the list of clinics from the service layer
                var clinics = _clinicService.GetAllClinic();

                if (clinics == null)  // Check if no clinics were found
                {
                    return NotFound("No clinics found.");
                }

                // Return a 200 OK response with the list of clinics
                return Ok(clinics);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error response if there is an exception
                return StatusCode(500, $"An error occurred while retrieving patients. {(ex.Message)}");
            }
        }
    }
}
