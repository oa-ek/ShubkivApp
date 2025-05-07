using WebApi.Models.Entity;

namespace WebApi.Repository.Interfaces
{
    public interface ITour
    {
        IEnumerable<Tour> GetAllTours();
        Tour GetToursById(int tourId);
        void CreateTour(Tour tour, List<int> guideIds);
        void DeleteTour(int id);
        void UpdateTour(Tour tour);

        Task RegisterForTour(int tourId, string userId);
    }
}
