using FleetManager.Model;

namespace FleetManager.Services
{
    public class LicenseValidator : Interfaces.ILicenseValidator
    {
        private static readonly Dictionary<VehicleType,DrivingLicences> licenceVehicleMap = new()
        {
            { VehicleType.Car, DrivingLicences.B },
            { VehicleType.Truck, DrivingLicences.C },
            { VehicleType.Motorcycle, DrivingLicences.A },
            { VehicleType.Bus, DrivingLicences.D }
        };
           
        public bool CanDrive(DrivingLicences driverLicence, VehicleType vehicleType)
        {
            if(!licenceVehicleMap.TryGetValue(vehicleType, out var requiredLicense))
            {
                throw new ArgumentException($"Driver does not have the required license category for {vehicleType}.");
            }
            return driverLicence.HasFlag(requiredLicense);
        }
    }
}
