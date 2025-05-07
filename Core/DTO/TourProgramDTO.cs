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
}
