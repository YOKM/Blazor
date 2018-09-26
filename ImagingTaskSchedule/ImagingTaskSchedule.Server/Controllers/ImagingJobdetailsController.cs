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
    [Route("api/ImagingJobdetails")]
    [ApiController]
    public class ImagingJobdetailsController : Controller
    {
        // private readonly KOFAXContext _context;

        KOFAXContext _context = new KOFAXContext();

        // GET: api/ImagingJobdetails
        [HttpGet]
        public IEnumerable <ImagingJobdetails> GetImagingJobdetails()
        {
            return _context.ImagingJobdetails;
        }
               

        // GET: api/ImagingJobdetails/5
        [HttpGet("{id}")]

        public IEnumerable<ImagingJobdetails> GetImagingJobdetails([FromRoute] int id)
        {
            var JobDetails = _context.ImagingJobdetails.Where(i => i.Jobid == id).ToList();
            return  JobDetails;
        }




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





        // POST: api/ImagingJobdetails
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

        // DELETE: api/ImagingJobdetails/5
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