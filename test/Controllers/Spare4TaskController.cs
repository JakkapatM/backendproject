﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Spare4TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public Spare4TaskController(DataContext context)
        {
            this._context = context;
        }
        public class Search
        {
            public int? detail_id { get; set; }
            public int? task_id { get; set; }
        }
        [HttpPost("getlist")]
        public async Task<ActionResult> GetList([FromQuery] Search? request)
        {
            List<Spare4Task> spare4Task = new List<Spare4Task>();
            if (request.detail_id != 0 && request.detail_id != null) spare4Task = this._context.Spare4Task.Where(w => w.detail_id == request.detail_id).ToList();
            else if (request.task_id != 0 && request.task_id != null) spare4Task = this._context.Spare4Task.Where(w => w.task_id == request.task_id).ToList();

            else spare4Task = this._context.Spare4Task.ToList();

            return Ok(spare4Task);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> Getall()
        {
            List<Spare4Task> Spare4Task = this._context.Spare4Task.ToList();
            return Ok(Spare4Task);
        }
        [HttpPost]
        public async Task<ActionResult> AddSpare4Task(Spare4Task Spare4Task)
        {
            this._context.Spare4Task.Add(Spare4Task);
            await this._context.SaveChangesAsync();
            return Ok(Spare4Task);
        }
        [HttpPut]
        public async Task<ActionResult> EditSpare4Task(Spare4Task Spare4Task)
        {
            this._context.Spare4Task.Attach(Spare4Task);
            this._context.Entry(Spare4Task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._context.SaveChangesAsync();
            return Ok(Spare4Task);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSpare4Task(int detailId)
        {
            Spare4Task Spare4Task = this._context.Spare4Task.Where(w => w.detail_id == detailId).FirstOrDefault();
            this._context.Spare4Task.Remove(Spare4Task);
            await this._context.SaveChangesAsync();
            return Ok(Spare4Task);
        }
    }
}


