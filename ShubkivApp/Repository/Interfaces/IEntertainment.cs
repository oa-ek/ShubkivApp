using ShubkivApp.Models.Entity;

namespace ShubkivApp.Repository.Interfaces
{
    public interface IEntertainment
    {
        IEnumerable<Event> GetAllEntertainments();
        Event GetEntertainmentById(int entertainmentId);
        void CreateEntertainment(Event entertainment);
        void DeleteEntertainment(int id);
        void UpdateEntertainment(Event entertainment);
    }
}
