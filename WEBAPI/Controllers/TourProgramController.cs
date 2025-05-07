using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Entity;
using WebApi.Repository;
using WebApi.Repository.Interfaces;
using WebApi.Models;
using Core.DTO;
using WebApi.Models.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourProgramController : ControllerBase
    {
        private readonly ITourProgram _repo;
        private readonly ApplicationDbContext _context;


        public TourProgramController(ITourProgram repo, ApplicationDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTourProgram([FromBody] Models.DTO.CreateTourProgramDTO dto)
        {
            await _repo.CreateTourProgramAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.DTO.CreateTourProgramDTO>>> GetAll()

        {
            var progarms = await _context.TourPrograms
                .Select(g => new Models.DTO.CreateTourProgramDTO
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();

            return Ok(progarms);
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<TourProgramViewModels>> GetProgram(int id)
        {
            var program = await _context.TourPrograms
                .Include(p => p.Days)
                    .ThenInclude(d => d.Events)
                        .ThenInclude(e => e.Location)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (program == null) return NotFound();

            var result = new TourProgramViewModels
            {
                Id = program.Id,
                Name = program.Name,
                Days = program.Days.Select(d => new DayViewModels
                {
                    Id = d.Id,
                    DayNumber = d.DayNumber,
                    Events = d.Events.Select(e => new EventViewModels
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Time = e.Time,
                        Location = new LocationViewModels
                        {
                            Id = e.Location.Id,
                            Name = e.Location.Name
                        }
                    }).ToList()
                }).ToList()
            };

            return Ok(result);
        }

    }
}
