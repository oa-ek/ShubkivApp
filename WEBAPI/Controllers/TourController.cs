using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.DTO;
using WebApi.Models.Entity;
using WebApi.Repository.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITour _tourRepository;
        private readonly ApplicationDbContext _context;

        public TourController(ITour tourRepository, ApplicationDbContext context)
        {
            _tourRepository = tourRepository;
            _context = context;
        }

        // GET: api/tour
        [HttpGet]
        public List<TourViewModel> GetAllTours()
        {
            return _context.Tours
                .Include(t => t.TourProgram)
                .Select(t => new TourViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Complexity = t.Complexity,
                    Category = t.Category,
                    Price = t.Price,
                    Date = t.Date,
                    MaxMembers = t.MaxMembers
                })
                .ToList();
        }


        // GET: api/tour/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tour = _tourRepository.GetToursById(id);
            if (tour == null)
                return NotFound();

            return Ok(tour);
        }

        // POST: api/tour
        [HttpPost]
        public IActionResult CreateTour([FromBody] Models.DTO.TourCreateModel model)
        {
            if (model == null)
                return BadRequest("Модель пуста.");

            var tourProgram = _context.TourPrograms.FirstOrDefault(tp => tp.Id == model.TourProgramId);

            if (tourProgram == null)
                return NotFound("Тур програма не знайдена.");

            var tour = new Tour
            {
                Name = model.Name,
                Complexity = model.Complexity,
                Category = model.Category,
                Price = model.Price,
                MaxMembers = model.MaxMembers,
                Date = model.Date,
                TourProgram = tourProgram,
                
            };

            _tourRepository.CreateTour(tour, model.TourGuideIds);
            return Ok();
        }

        // PUT: api/tour/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Tour updatedTour)
        {
            var existingTour = _tourRepository.GetToursById(id);
            if (existingTour == null)
                return NotFound();


            existingTour.Name = updatedTour.Name;
            existingTour.Complexity = updatedTour.Complexity;
            existingTour.Category = updatedTour.Category;
            existingTour.Price = updatedTour.Price;
            existingTour.MaxMembers = updatedTour.MaxMembers;
            existingTour.CurrentMembers = updatedTour.CurrentMembers;
            existingTour.Date = updatedTour.Date;
            existingTour.Status = updatedTour.Status;
            existingTour.TourProgram = updatedTour.TourProgram;
            //existingTour.Image = updatedTour.Image;

            _tourRepository.UpdateTour(existingTour); 

            return NoContent();
        }

        // DELETE: api/tour/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTour = _tourRepository.GetToursById(id);
            if (existingTour == null)
                return NotFound();

            _tourRepository.DeleteTour(id);
            return NoContent();
        }


    }
}
