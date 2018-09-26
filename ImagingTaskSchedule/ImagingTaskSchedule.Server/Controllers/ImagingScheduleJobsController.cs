using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImagingTaskSchedule.Shared.Models;

namespace ImagingTaskSchedule.Server.Controllers
{
    [Route("api/ImagingScheduleJobs")]
    [Produces("application/json")]
    [ApiController]
    public class ImagingScheduleJobsController : Controller
    {
        // private readonly KOFAXContext _context;

        KOFAXContext _context = new KOFAXContext();


        /* public ImagingScheduleJobsController(KOFAXContext context)
         {
             _context = context;
         }*/




        // GET: api/ImagingScheduleJobs
        [HttpGet]
        public IEnumerable<ImagingScheduleJob> GetImagingScheduleJob()
        {
            return _context.ImagingScheduleJob;
        }

        // GET: api/ImagingScheduleJobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImagingSheduleJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var JobMasters = await _context.ImagingScheduleJob.FindAsync(id);

            if (JobMasters == null)
            {
                return NotFound();
            }

            return Ok(JobMasters);
        }
        // PUT: api/ImagingScheduleJobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagingScheduleJob([FromRoute] int id, [FromBody] ImagingScheduleJob imagingScheduleJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagingScheduleJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagingScheduleJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagingScheduleJobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ImagingScheduleJobs
        [HttpPost]
        public async Task<IActionResult> PostImagingScheduleJob([FromBody] ImagingScheduleJob imagingScheduleJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ImagingScheduleJob.Add(imagingScheduleJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagingScheduleJob", new { id = imagingScheduleJob.Id }, imagingScheduleJob);
        }

        // DELETE: api/ImagingScheduleJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagingScheduleJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imagingScheduleJob = await _context.ImagingScheduleJob.FindAsync(id);
            if (imagingScheduleJob == null)
            {
                return NotFound();
            }

            _context.ImagingScheduleJob.Remove(imagingScheduleJob);
            await _context.SaveChangesAsync();

            return Ok(imagingScheduleJob);
        }

        private bool ImagingScheduleJobExists(int id)
        {
            return _context.ImagingScheduleJob.Any(e => e.Id == id);
        }
    }
}