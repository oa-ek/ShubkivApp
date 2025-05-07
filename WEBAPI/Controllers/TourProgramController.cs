using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.DTO;
using WebApi.Models.Entity;
using WebApi.Repository;
using WebApi.Repository.Interfaces;

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
        public async Task<IActionResult> CreateTourProgram([FromBody] CreateTourProgramDTO dto)
        {
            await _repo.CreateTourProgramAsync(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateTourProgramDTO>>> GetAll()
        
        {
            var progarms = await _context.TourPrograms
                .Select(g => new CreateTourProgramDTO
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();

            return Ok(progarms);
        }
    }
}
