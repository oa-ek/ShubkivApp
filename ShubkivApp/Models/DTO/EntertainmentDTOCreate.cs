using System.ComponentModel.DataAnnotations;

namespace ShubkivApp.Models.DTO
{
    public class EntertainmentDTOCreate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Назва обов'язкова")]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
