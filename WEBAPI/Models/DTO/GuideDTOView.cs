using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO
{
    public class GuideDTOView
    {
        public int Id { get; set; }
		public string Name { get; set; }
        public string Specialty { get; set; }
        public string Contact { get; set; }
    }
}
