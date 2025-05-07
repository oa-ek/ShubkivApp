using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
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

    public class CreateTourProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TourViewModel
    {
        public int Id { get; set; }                     
        public string Name { get; set; }                
        public string Complexity { get; set; }          
        public string Category { get; set; }        
        public int Price { get; set; }          
        public int MaxMembers { get; set; }     
        public DateTime Date { get; set; }     
        public string TourProgramName { get; set; }  
        public List<string> TourGuideNames { get; set; } = new();
    }

    public class TourDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Complexity { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int MaxMembers { get; set; }
        public DateTime Date { get; set; }
        public List<GuideViewModel> Guides { get; set; } = new();
        public TourProgramViewModel? TourProgram { get; set; }
    }

    public class TourProgramViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Steps { get; set; } = new();
    }

}
