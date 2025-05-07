using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class GuideDTOCreate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Спеціальність обов'язкова")]
        public string Specialty { get; set; } = string.Empty;

        [Required(ErrorMessage = "Контакт обов'язковий")]
        public string Contact { get; set; } = string.Empty;
    }

    public class GuideViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
    }
}
