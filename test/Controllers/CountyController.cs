using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly DataContext _context;

        public CountyController(DataContext context)
        {
            this._context = context;
        }
        public class Search
        {
            public string county_name { get; set; }
        }
        [HttpGet]
        public async Task<ActionResult> GetList(string countyname)
        {
            List<County> county = this._context.county.Where(w => w.county_name == countyname).ToList();
            return Ok(county);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetList()
        {
            List<County> county = this._context.county.ToList();
            return Ok(county);
        }
        [HttpPost]
        public async Task<ActionResult> AddCounty(County county)
        {
            this._context.county.Add(county);
            await this._context.SaveChangesAsync();
            return Ok(county);
        }
        [HttpPut]
        public async Task<ActionResult> EditCounty(County county)
        {
            this._context.county.Attach(county);
            this._context.Entry(county).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._context.SaveChangesAsync();
            return Ok(county);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCounty(string countyId)
        {
            County county = this._context.county.Where(w => w.county_name == countyId).FirstOrDefault();
            this._context.county.Remove(county);
            await this._context.SaveChangesAsync();
            return Ok(county);
        }
    }
}


