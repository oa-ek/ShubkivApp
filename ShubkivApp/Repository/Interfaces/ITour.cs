using ShubkivApp.Models.Entity;

namespace ShubkivApp.Repository.Interfaces
{
    public interface ITour
    {
        IEnumerable<Tour> GetAllTours();
        Tour GetToursById(int tourId);
        void CreateTour(Tour tour);
        void DeleteTour(int id);

        Task RegisterForTour(int tourId, string userId);
    }
}
