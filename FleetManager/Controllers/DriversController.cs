using FleetManager.Database;
using FleetManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FleetManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly AppDbContext context;
        public DriversController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var drivers = await context.Drivers.ToListAsync();
            return Ok(drivers);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var driver = await context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDriver(DriverDto driverDto)
        {
            var driver = new Model.Driver
            {
                Name = driverDto.Name,
                Surname = driverDto.Surname,
                Licence = driverDto.Licence
            };
            
            await context.Drivers.AddAsync(driver);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDriver), new { id = driver.DriverId }, driver);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, DriverDto driverDto)
        {
            
            var driver = await context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            driver.Name = driverDto.Name;
            driver.Surname = driverDto.Surname;
            driver.Licence = driverDto.Licence;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            context.Drivers.Remove(driver);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
