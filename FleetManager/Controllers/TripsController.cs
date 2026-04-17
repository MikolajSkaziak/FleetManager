using FleetManager.Database;
using FleetManager.DTOs;
using FleetManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly ITripService tripService;
        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip(TripDto tripDto)
        {
            try
            {
                var trip = await tripService.CreateTripAsync(tripDto);
                return Ok(new { tripId = trip.TripId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            try
            {
                var trips = await tripService.GetAllTripsAsync();
                return Ok(trips);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
