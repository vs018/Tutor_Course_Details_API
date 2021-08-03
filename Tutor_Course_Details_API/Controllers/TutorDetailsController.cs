using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutor_Course_Details_API.Data;
using Tutor_Course_Details_API.Models;

namespace Tutor_Course_Details_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorDetailsController : ControllerBase
    {
        private readonly Tutor_Course_Details_APIContext _context;

        public TutorDetailsController(Tutor_Course_Details_APIContext context)
        {
            _context = context;
        }

        // GET: api/TutorDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TutorDetails>>> GetTutorDetails()
        {
            return await _context.TutorDetails.ToListAsync();
        }

        // GET: api/TutorDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDetails>> GetTutorDetails(long id)
        {
            var tutorDetails = await _context.TutorDetails.FindAsync(id);

            if (tutorDetails == null)
            {
                return NotFound();
            }

            return tutorDetails;
        }

        // PUT: api/TutorDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutorDetails(long id, TutorDetails tutorDetails)
        {
            if (id != tutorDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(tutorDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorDetailsExists(id))
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

        // POST: api/TutorDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TutorDetails>> PostTutorDetails(TutorDetails tutorDetails)
        {
            _context.TutorDetails.Add(tutorDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutorDetails", new { id = tutorDetails.Id }, tutorDetails);
        }

        // DELETE: api/TutorDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TutorDetails>> DeleteTutorDetails(long id)
        {
            var tutorDetails = await _context.TutorDetails.FindAsync(id);
            if (tutorDetails == null)
            {
                return NotFound();
            }

            _context.TutorDetails.Remove(tutorDetails);
            await _context.SaveChangesAsync();

            return tutorDetails;
        }

        private bool TutorDetailsExists(long id)
        {
            return _context.TutorDetails.Any(e => e.Id == id);
        }
    }
}
