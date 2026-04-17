namespace FleetManager.DTOs
{
    public class TripDto
    {
        public required int DriverId { get; set; }
        public required int VehicleId { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required float Distance { get; set; }
        public required float AverageFuelConsumption { get; set; }
    }
}
