using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManager.Model
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public required string Model { get; set; }
        public required string Brand { get; set; }

        public required string PlateNumber { get; set; }

        public required VehicleType Type { get; set; }
    }
    public enum VehicleType
    {
        Motorcycle,
        Bus,
        Car,
        Truck

    }
}
