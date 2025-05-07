using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.DTO;
using WebApi.Models.Entity;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository
{
    public class TourProgramRepository : ITourProgram
    {
        private readonly ApplicationDbContext _context;
        public TourProgramRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateTourProgramAsync(CreateTourProgramDTO dto)
        {
            var program = new TourProgram
            {
                Name = dto.Name,
                Days = dto.Days.Select(d => new Day
                {
                    DayNumber = d.DayNumber,
                    Events = d.Events.Select(e => new Event
                    {
                        Name = e.Name,
                        Description = e.Description,
                        Time = e.Time,
                        Location = new Location
                        {
                            Name = e.LocationName,
                            Adress = "test",
                            Longtitude = 1.1,
                            Latitude = 1.1
                        }
                    }).ToList()
                }).ToList()
            };

            _context.TourPrograms.Add(program);
            await _context.SaveChangesAsync();
        }
        public void DeleteTourProgram(int id)
        {
            var deletedTourProgram = _context.TourPrograms.FirstOrDefault(g => g.Id == id);
            if (deletedTourProgram != null)
            {
                _context.TourPrograms.Remove(deletedTourProgram);
                _context.SaveChanges();
            }
        }
        public IEnumerable<TourProgram> GetAllProgram()
        {
            return _context.TourPrograms.ToList();

        }
        public TourProgram GetTourProgramById(int tourProgramId)
        {
            return _context.TourPrograms.FirstOrDefault(p => p.Id == tourProgramId);
        }
        public void UpdateTourProgram(TourProgram tourProgram)
        {
            var existingTourProgram = _context.TourPrograms.Find(tourProgram.Id);
            if (existingTourProgram != null)
            {
                existingTourProgram.Name = tourProgram.Name;
                existingTourProgram.Days = tourProgram.Days;
                _context.SaveChanges();
            }
        }
    }
}
