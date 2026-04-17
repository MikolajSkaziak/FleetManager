using FleetManager.Model;

namespace FleetManager.Services.Interfaces
{
    public interface ILicenseValidator
    {
        bool CanDrive(DrivingLicences driverLicence, VehicleType vehicleType);
    }
}
