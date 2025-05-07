namespace WebApi.Models.DTO
{
    public class CreateDayDTO
    {
        public int DayNumber { get; set; }
        public List<CreateEventDTO> Events { get; set; }
    }
}
