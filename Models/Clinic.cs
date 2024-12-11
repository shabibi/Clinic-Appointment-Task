using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicAppointmentTask.Models
{
    public class Clinic
    {
        [Key]
        public int CID { get; set; }

        [Required]
        public string specilization { get; set; }

        [Range(1, 20)]
        public int NumberOfSlots { get; set; }

        [JsonIgnore]
        public virtual ICollection<Appointment> Appoinments { get; set; }

    }
}
