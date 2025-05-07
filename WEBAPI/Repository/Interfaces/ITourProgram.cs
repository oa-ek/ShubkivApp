using WebApi.Models.DTO;
using WebApi.Models.Entity;

namespace WebApi.Repository.Interfaces
{
	public interface ITourProgram
    {
        IEnumerable<TourProgram> GetAllTourPrograms();
        TourProgram GetTourProgramById(int tourProgramId);
        Task CreateTourProgramAsync(CreateTourProgramDTO dto);
        void DeleteTourProgram(int id);
        void UpdateTourProgram(TourProgram tourProgram);
    }
}
