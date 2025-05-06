using ShubkivApp.Models.Entity;

namespace ShubkivApp.Repository.Interfaces
{
	public interface IGuide
	{
		IEnumerable<Guide> GetAllGuides();
		Guide GetGuideById(int guideId);
		void CreateGuide(Guide guide);
		void DeleteGuide(int id);
		void UpdateGuide(Guide guide);
	}
}
