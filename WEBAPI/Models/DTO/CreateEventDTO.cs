namespace WebApi.Models.DTO
{
    public class CreateEventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly Time { get; set; }
        public string LocationName { get; set; }
    }
}
