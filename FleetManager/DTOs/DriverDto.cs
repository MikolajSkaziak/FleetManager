using FleetManager.Model;

namespace FleetManager.DTOs
{
    public class DriverDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DrivingLicences Licence { get; set; }
    }
}
