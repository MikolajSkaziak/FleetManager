using FleetManager.Database;
using FleetManager.DTOs;
using FleetManager.Model;
using FleetManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Services
{
    public class TripService : Interfaces.ITripService
    {
        private readonly Interfaces.ILicenseValidator licenseValidator;
        private readonly AppDbContext appDbContext;
        public TripService(ILicenseValidator licenseValidator, AppDbContext appDbContext)
        {
            this.licenseValidator = licenseValidator;
            this.appDbContext = appDbContext;
        }
        public async Task<Trip> CreateTripAsync(TripDto tripDto)
        {
            if(tripDto.StartTime >= tripDto.EndTime)
            {
                throw new ArgumentException("Start time must be before end time.");
            }
            var driver = await appDbContext.Drivers.FindAsync(tripDto.DriverId);
            var vehicle = await appDbContext.Vehicles.FindAsync(tripDto.VehicleId);
            if (driver == null || vehicle == null)
            {
                throw new Exception("Driver or Vehicle not found.");
            }
            if (!licenseValidator.CanDrive(driver.Licence, vehicle.Type))
            {
                throw new InvalidOperationException($"Driver {driver.Name} doesn't have permission to drive {vehicle.Type}");
            }
            var trip = new Trip
            {
                DriverId = tripDto.DriverId,
                Driver = driver,
                VehicleId = tripDto.VehicleId,
                Vehicle = vehicle,
                StartTime = tripDto.StartTime,
                EndTime = tripDto.EndTime,
                Distance = tripDto.Distance,
                AverageFuelConsumption = tripDto.AverageFuelConsumption
            };

            await appDbContext.Trips.AddAsync(trip);
            await appDbContext.SaveChangesAsync();

            return trip;
        }

        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await appDbContext.Trips
                .Include(t => t.Driver)
                .Include(t => t.Vehicle)
                .OrderByDescending(t => t.StartTime)
                .ToListAsync();
        }
    }
}