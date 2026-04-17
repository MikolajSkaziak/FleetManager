using FleetManager.Model;
using FleetManager.Services;
using Xunit;

namespace FleetManager.Tests
{
    public class LicenseValidatorTests
    {
        private readonly LicenseValidator validator;

        public LicenseValidatorTests()
        {
            validator = new LicenseValidator();
        }

        [Theory]
        [InlineData(DrivingLicences.B, VehicleType.Car, true)]      
        [InlineData(DrivingLicences.B, VehicleType.Truck, false)]   
        [InlineData(DrivingLicences.C, VehicleType.Truck, true)]   
        [InlineData(DrivingLicences.A | DrivingLicences.B, VehicleType.Bus, false)]
        public void CanDrive_ShouldReturnExpectedResult(DrivingLicences driverLicence, VehicleType vehicleType, bool expected)
        {
            var result = validator.CanDrive(driverLicence, vehicleType);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanDrive_ShouldHandleMultipleLicenses()
        {
            var driverLicence = DrivingLicences.A | DrivingLicences.C;

            var result = validator.CanDrive(driverLicence, VehicleType.Car);

            Assert.False(result);
        }
    }
}