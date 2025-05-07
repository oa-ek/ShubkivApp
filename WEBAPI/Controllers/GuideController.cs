using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Entity;
using WebApi.Repository;
using WebApi.Repository.Interfaces;
using Core.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuideController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGuide _repo;


        public GuideController(ApplicationDbContext context, IGuide repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/guide
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuideViewModel>>> GetAll()
        {
            var guides = await _context.Guides
                .Select(g => new GuideViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Specialty = g.Specialty,
                    Contact = g.Contact
                }).ToListAsync();

            return Ok(guides);
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
        public async Task<IActionResult> Create([FromBody] GuideDTOCreate dto)
        {
            var guide = new Guide
            {
                Name = dto.Name,
                Specialty = dto.Specialty,
                Contact = dto.Contact
            };

            await _repo.CreateGuide(guide);
            return Ok(guide.Id);
        }

        // PUT: api/guide/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuide(int id, Guide guide)
        {
            if (id != guide.Id)
            {
                return BadRequest("ID не співпадає");
            }

            var existingGuide = _repo.GetGuideById(id);
            if (existingGuide == null)
            {
                return NotFound("Гіда не знайдено");
            }

            _repo.UpdateGuide(guide); 
            return NoContent();
        }

        // DELETE: api/guide/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var existingGuide = _context.Guides.FirstOrDefault(g => g.Id == id);
            if (existingGuide == null)
            {
                return NotFound("Гіда не знайдено.");
            }

            _repo.DeleteGuide(id);
            return NoContent();
        }
    }
}
