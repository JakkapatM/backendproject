using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly DataContext _context;

        public VehicleController(DataContext context)
        {
            this._context = context;
        }
        public class Search
        {
            public int? vehicle_id { get; set; }
            public int? customer_id { get; set; }
            public string? license_name { get; set; }
        }
        [HttpPost("getlist")]
        public async Task<ActionResult> GetList([FromQuery] Search? request)
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            if (request.vehicle_id != 0 && request.vehicle_id != null) vehicle = this._context.vehicle.Where(w => w.vehicle_id == request.vehicle_id).ToList();
            else if (request.customer_id != 0 && request.customer_id != null) vehicle = this._context.vehicle.Where(w => w.customer_id == request.customer_id).ToList();
            else if (!String.IsNullOrEmpty(request.license_name)) vehicle = this._context.vehicle.Where(w => w.license_name == request.license_name).ToList();

            else vehicle = this._context.vehicle.ToList();

            return Ok(vehicle);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> Getall()
        {
            List<Vehicle> vehicle = this._context.vehicle.ToList();
            return Ok(vehicle);
        }
        [HttpPost]
        public async Task<ActionResult> AddVehicle(Vehicle vehicle)
        {
            this._context.vehicle.Add(vehicle);
            await this._context.SaveChangesAsync();
            return Ok(vehicle);
        }
        [HttpPut]
        public async Task<ActionResult> EditVehicle(Vehicle vehicle)
        {
            this._context.vehicle.Attach(vehicle);
            this._context.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._context.SaveChangesAsync();
            return Ok(vehicle);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteVehicle(int vehicleId)
        {
            Vehicle vehicle = this._context.vehicle.Where(w => w.vehicle_id == vehicleId).FirstOrDefault();
            this._context.vehicle.Remove(vehicle);
            await this._context.SaveChangesAsync();
            return Ok(vehicle);
        }
    }
}


