using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class CreateTourProgramDTOs
    {
        public string Name { get; set; } = string.Empty;
        public List<DayDTO> Days { get; set; } = new();
    }

    public class DayDTO
    {
        public int DayNumber { get; set; }
        public List<EventDTO> Events { get; set; } = new();
    }

    public class EventDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
    }
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
