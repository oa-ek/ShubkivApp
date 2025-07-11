﻿using System.ComponentModel.DataAnnotations;

namespace ShubkivApp.Models.DTO
{
    public class GuideDTOCreate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Спеціальність обов'язкова")]
        public string Specialty { get; set; }
        [Required(ErrorMessage = "Контакти обов'язкові")]
        public string Contact { get; set; }
    }
}
