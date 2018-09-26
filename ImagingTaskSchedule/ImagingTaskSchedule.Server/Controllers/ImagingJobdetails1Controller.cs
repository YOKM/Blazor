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
    [Produces("application/json")]
    [Route("api/ImagingJobdetails1")]
    [ApiController]
    public class ImagingJobdetails1Controller : Controller
    {
        //private readonly KOFAXContext _context;

        KOFAXContext _context = new KOFAXContext();

        // GET: api/ImagingJobdetails1
        [HttpGet]
        public IEnumerable<ImagingJobdetails> GetImagingJobdetails()
        {
            return _context.ImagingJobdetails;
        }

        // GET: api/ImagingJobdetails1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImagingJobdetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var imagingJobdetails = await _context.ImagingJobdetails.FindAsync(id);

            var imagingJobdetails = await _context.ImagingJobdetails.SingleOrDefaultAsync(m => m.Jobid == id);

            if (imagingJobdetails == null)
            {
                return NotFound();
            }

            return Ok(imagingJobdetails);
        }

        // PUT: api/ImagingJobdetails1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagingJobdetails([FromRoute] int id, [FromBody] ImagingJobdetails imagingJobdetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagingJobdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagingJobdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagingJobdetailsExists(id))
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

        // POST: api/ImagingJobdetails1
        [HttpPost]
        public async Task<IActionResult> PostImagingJobdetails([FromBody] ImagingJobdetails imagingJobdetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ImagingJobdetails.Add(imagingJobdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagingJobdetails", new { id = imagingJobdetails.Id }, imagingJobdetails);
        }

        // DELETE: api/ImagingJobdetails1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagingJobdetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imagingJobdetails = await _context.ImagingJobdetails.FindAsync(id);
            if (imagingJobdetails == null)
            {
                return NotFound();
            }

            _context.ImagingJobdetails.Remove(imagingJobdetails);
            await _context.SaveChangesAsync();

            return Ok(imagingJobdetails);
        }

        private bool ImagingJobdetailsExists(int id)
        {
            return _context.ImagingJobdetails.Any(e => e.Id == id);
        }
    }
}