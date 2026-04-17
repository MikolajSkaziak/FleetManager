using FleetManager.Database;
using FleetManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext context;

        public VehiclesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await context.Vehicles.ToListAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(VehicleDto vehicleDto)
        {

            var vehicle = new Model.Vehicle
            {
                Model = vehicleDto.Model,
                Brand = vehicleDto.Brand,
                PlateNumber = vehicleDto.PlateNumber,
                Type = vehicleDto.Type
            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, VehicleDto vehicleDto)
        {
         
            var vehicle = await context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            vehicle.Model = vehicleDto.Model;
            vehicle.Brand = vehicleDto.Brand;
            vehicle.PlateNumber = vehicleDto.PlateNumber;
            vehicle.Type = vehicleDto.Type;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
