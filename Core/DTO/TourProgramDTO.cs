using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class TourProgramViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DayViewModels> Days { get; set; } = new();
    }

    public class DayViewModels
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public List<EventViewModels> Events { get; set; } = new();
    }

    public class EventViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly Time { get; set; }
        public LocationViewModels Location { get; set; } = new();
    }

    public class LocationViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
