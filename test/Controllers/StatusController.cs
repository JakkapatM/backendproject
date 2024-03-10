using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            this._context = context;
        }
        public class Search
        {
            public string status_phase { get; set; }
        }
        [HttpGet]
        public async Task<ActionResult> GetList(string statusphase)
        {
            List<Status> status = this._context.status.Where(w => w.status_phase == statusphase).ToList();
            return Ok(status);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetList()
        {
            List<Status> status = this._context.status.ToList();
            return Ok(status);
        }
        [HttpPost]
        public async Task<ActionResult> AddStatus(Status status)
        {
            this._context.status.Add(status);
            await this._context.SaveChangesAsync();
            return Ok(status);
        }
        [HttpPut]
        public async Task<ActionResult> EditStatus(Status status)
        {
            this._context.status.Attach(status);
            this._context.Entry(status).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._context.SaveChangesAsync();
            return Ok(status);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteStatus(string statusphase)
        {
            Status status = this._context.status.Where(w => w.status_phase == statusphase).FirstOrDefault();
            this._context.status.Remove(status);
            await this._context.SaveChangesAsync();
            return Ok(status);
        }
    }
}
