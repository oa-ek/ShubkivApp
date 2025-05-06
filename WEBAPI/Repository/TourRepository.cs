using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Entity;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository
{
    public class TourRepository : ITour
    {
        private readonly ApplicationDbContext _context;


        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateTour(Tour tour)
        {
            if (tour == null)
            {
                throw new ArgumentNullException(nameof(tour), "Не всі поля отримали значення");
            }

            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        public void DeleteTour(int id)
        {
            var deletedTour = _context.Tours.FirstOrDefault(t => t.Id == id);
            if (deletedTour != null)
            {
                _context.Tours.Remove(deletedTour);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Tour> GetAllTours()
        {
            return _context.Tours
                .Include(t => t.Image)
                .ToList();
        }

        public IEnumerable<Tour> GetExpectedTours()
        {
            return _context.Tours.Where(t => t.Status == "В очікуванні").ToList();
        }

        public IEnumerable<Tour> GetUpcomingTours()
        {
            var today = DateTime.Now;
            var upcomingTours = today.AddDays(7);

            return _context.Tours.Where(t => t.Date <= upcomingTours && t.Date >= today).ToList();
        }

        public Tour GetToursById(int tourId)
        {
            return _context.Tours.FirstOrDefault(p => p.Id == tourId);
        }

        public async Task RegisterForTour(int tourId, string userId)
        {
            var tour = GetToursById(tourId);

            if (tour == null)
            {
                throw new Exception("Tour not found");
            }

            var membersInTour = tour.CurrentMembers;
            if (membersInTour >= tour.MaxMembers)
            {
                throw new Exception("There are no places on the tour.");
            }

            var tourClient = new TourClients
            {
                ClientId = userId,
                TourId = tourId,
                BookingDate = DateTime.Now
            };

            tour.CurrentMembers++;  

            _context.TourClients.Add(tourClient);
            await _context.SaveChangesAsync(); 
        }
        public void UpdateTour(Tour updatedTour)
        {
            if (updatedTour == null)
            {
                throw new ArgumentNullException(nameof(updatedTour), "Дані для оновлення відсутні");
            }

            var existingTour = _context.Tours
                .Include(t => t.Image)
                .Include(t => t.TourProgram)
                .FirstOrDefault(t => t.Id == updatedTour.Id);

            if (existingTour == null)
            {
                throw new InvalidOperationException($"Тур з ID {updatedTour.Id} не знайдено");
            }


            existingTour.Name = updatedTour.Name;
            existingTour.Complexity = updatedTour.Complexity;
            existingTour.Category = updatedTour.Category;
            existingTour.Price = updatedTour.Price;
            existingTour.MaxMembers = updatedTour.MaxMembers;
            existingTour.CurrentMembers = updatedTour.CurrentMembers;
            existingTour.Date = updatedTour.Date;
            existingTour.Status = updatedTour.Status;

            existingTour.Image = updatedTour.Image;
            existingTour.TourProgram = updatedTour.TourProgram;

            _context.Tours.Update(existingTour);
            _context.SaveChanges();
        }


    }
}
