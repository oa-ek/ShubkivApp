using WebApi.Models.Entity;

namespace WebApi.Repository.Interfaces
{
    public interface ILocation
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int locationId);
        void CreateLocation(Location location);
        void DeleteLocation(int id);
		void UpdateLocation(Location location);

	}
}
