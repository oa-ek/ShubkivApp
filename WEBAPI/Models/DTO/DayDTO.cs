namespace WebApi.Models.DTO
{
    public class DayDTO
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public List<EventDTO> Events { get; set; } = new List<EventDTO>();
    }
}
