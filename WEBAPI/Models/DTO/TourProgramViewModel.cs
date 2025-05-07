namespace WebApi.Models.DTO
{
    public class TourProgramViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DayDTO> Days { get; set; } = new List<DayDTO>();
        public DayDTO CurrentDay { get; set; } = new DayDTO();
    }
}
