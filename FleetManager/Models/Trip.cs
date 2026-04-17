using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManager.Model
{
    [Table("Trips")]
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public required Driver Driver { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public required Vehicle Vehicle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Range(0.1, 10000, ErrorMessage = "Distance must be positive.")]
        public float Distance { get; set; }
        [Range(0.1, 100, ErrorMessage = "Average fuel consumption must be positive.")]
        public float AverageFuelConsumption { get; set; }

    }
}
