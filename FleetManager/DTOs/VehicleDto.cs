using FleetManager.Model;
using System.ComponentModel.DataAnnotations;

namespace FleetManager.DTOs
{
    public class VehicleDto
    {
        [MaxLength(50)]
        public required string Model { get; set; }
        [MaxLength(50)]

        public required string Brand { get; set; }
        public required string PlateNumber { get; set; }
        public required VehicleType Type { get; set; }
    }
}
