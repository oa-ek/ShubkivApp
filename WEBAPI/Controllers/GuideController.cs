using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Entity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuideController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/guide
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guide>>> GetAllGuides()
        {
            return await _context.Guides.ToListAsync();
        }

        // GET: api/guide/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guide>> GetGuide(int id)
        {
            var guide = await _context.Guides.FindAsync(id);

            if (guide == null)
            {
                return NotFound();
            }

            return guide;
        }

        // POST: api/guide
        [HttpPost]
        public async Task<ActionResult<Guide>> CreateGuide(Guide guide)
        {
            if (guide == null)
                return BadRequest("Гід не може бути null");

            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuide), new { id = guide.Id }, guide);
        }

        // PUT: api/guide/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuide(int id, Guide guide)
        {
            if (id != guide.Id)
            {
                return BadRequest("ID не співпадає");
            }

            var existingGuide = await _context.Guides.FindAsync(id);
            if (existingGuide == null)
            {
                return NotFound("Гіда не знайдено");
            }

            existingGuide.Name = guide.Name;
            existingGuide.Specialty = guide.Specialty;
            existingGuide.Contact = guide.Contact;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/guide/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return NotFound();
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
