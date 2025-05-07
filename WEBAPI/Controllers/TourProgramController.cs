using Microsoft.AspNetCore.Mvc;
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

        public TourProgramController(ITourProgram repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTourProgram([FromBody] CreateTourProgramDTO dto)
        {
            await _repo.CreateTourProgramAsync(dto);
            return Ok();
        }
    }
}
