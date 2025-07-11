﻿namespace ShubkivApp.Models.Entity
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly Time { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int? DayId { get; set; }
        public Day? Day { get; set; }

        public EventImage? Image { get; set; }

        //public ICollection<TourEvents> TourEvents { get; set; }
    }
}
