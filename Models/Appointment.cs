using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClinicAppointmentTask.Models
{
    [PrimaryKey(nameof(CID), nameof(PID), nameof(date))]
    public class Appointment
    {
        public int SlotNumber { get; set; }

        public DateTime date { get; set; }

        [ForeignKey("Patient")]
        public int PID { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }

        [ForeignKey("Clinic")]
        public int CID { get; set; }
        [JsonIgnore]
        public virtual Clinic Clinic { get; set; }
    }
}
