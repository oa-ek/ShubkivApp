using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entity;
using WebApi.Repository.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITour _tourRepository;

        public TourController(ITour tourRepository)
        {
            _tourRepository = tourRepository;
        }

        // GET: api/tour
        [HttpGet]
        public IActionResult GetAll()
        {
            var tours = _tourRepository.GetAllTours();
            return Ok(tours);
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
        public IActionResult Create([FromBody] Tour newTour)
        {
            if (newTour == null)
                return BadRequest("Невірні дані");

            _tourRepository.CreateTour(newTour);
            return CreatedAtAction(nameof(GetById), new { id = newTour.Id }, newTour);
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
            existingTour.Image = updatedTour.Image;

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
