namespace WebApi.Models.DTO
{
    public class TourCreateModel
    {
        public string Name { get; set; }
        public string Complexity { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int MaxMembers { get; set; }
        public DateTime Date { get; set; }
        public int TourProgramId { get; set; }
        public List<int> TourGuideIds { get; set; } = new();
    }
}
