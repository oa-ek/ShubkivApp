using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Entity;
using WebApi.Repository.Interfaces;
using Core.DTO;

namespace WebApi.Repository
{
	public class GuideRepository : IGuide
	{
		private readonly ApplicationDbContext _context;

		public GuideRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateGuide(Guide guide)
		{
            await _context.Guides.AddAsync(guide);
            await _context.SaveChangesAsync();
        }

		public void DeleteGuide(int id)
		{
			var deletedGuide = _context.Guides.FirstOrDefault(g => g.Id == id);
			if (deletedGuide != null)
			{
				_context.Guides.Remove(deletedGuide);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Guide> GetAllGuides()
		{
			return _context.Guides.ToList();
		}

		public Guide GetGuideById(int guideId)
		{
			return _context.Guides.FirstOrDefault(p => p.Id == guideId);
		}
        public void UpdateGuide(Guide guide)
        {
            var existingGuide = _context.Guides.Find(guide.Id);
            if (existingGuide != null)
            {
                existingGuide.Name = guide.Name;
                existingGuide.Specialty = guide.Specialty;
                existingGuide.Contact = guide.Contact;
                _context.SaveChanges();
            }
        }

    }
}
