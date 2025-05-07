using WebApi.Models.Entity;

namespace WebApi.Repository.Interfaces
{
	public interface IGuide
	{
		IEnumerable<Guide> GetAllGuides();
		Guide GetGuideById(int guideId);
		Task CreateGuide(Guide guide);
		void DeleteGuide(int id);
		void UpdateGuide(Guide guide);
	}
}
