using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Spare_partController : ControllerBase
    {
        private readonly DataContext _context;
        public Spare_partController(DataContext context)
        {
        this._context = context;
        }
        public class Search
        {
            public int? spare_id { get; set; }
            public string? spare_name { get; set; }
        }
        [HttpPost("getlist")]
        public async Task<ActionResult> GetList( Search? request )
        {
            List<Spare_part> spare_part=new List<Spare_part>();
                if ( request.spare_id != 0&&request.spare_id != null) spare_part = this._context.spare_part.Where(w => w.spare_id == request.spare_id).ToList();
                else if ( !String.IsNullOrEmpty(request.spare_name)) spare_part = this._context.spare_part.Where(w => w.spare_name == request.spare_name).ToList();

            else spare_part = this._context.spare_part.ToList();

            return Ok(spare_part);
        }
        [HttpPost]
        public async Task<ActionResult> AddSpare_part(Spare_part spare_part)
        {
            this._context.spare_part.Add(spare_part);
            await this._context.SaveChangesAsync();
            return Ok(spare_part);
        }
        [HttpPut]
        public async Task<ActionResult> EditSpare_part(Spare_part spare_part)
        {
            this._context.spare_part.Attach(spare_part);
            this._context.Entry(spare_part).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._context.SaveChangesAsync();
            return Ok(spare_part);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSpare_part(int spareId)
        {
            Spare_part spare_part = this._context.spare_part.Where(w => w.spare_id == spareId).FirstOrDefault();
            this._context.spare_part.Remove(spare_part);
            await this._context.SaveChangesAsync();
            return Ok(spare_part);
        }
    }
}
