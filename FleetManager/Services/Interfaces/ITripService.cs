using FleetManager.DTOs;
using FleetManager.Model;

namespace FleetManager.Services.Interfaces
{
    public interface ITripService
    {
        Task<Trip> CreateTripAsync(TripDto tripDto);
        Task<IEnumerable<Trip>> GetAllTripsAsync();
    }
}
