﻿using ShubkivApp.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace ShubkivApp.Models.DTO
{
    public class TourDTOCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<TourGuides> TourGuides { get; set; }
        //public ICollection<TourLocations> TourLocations { get; set; }
        //public ICollection<TourEvents> TourEvents { get; set; }
        public ICollection<TourClients> TourClients { get; set; }
        public string Complexity { get; set; }
        public int Price { get; set; }
        public int MaxMembers { get; set; }
        public int Members { get; set; }
        public DateTime Date { get; set; }
        public string ImageFile { get; set; }
    }
}
