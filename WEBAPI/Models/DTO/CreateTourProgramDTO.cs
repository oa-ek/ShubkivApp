namespace WebApi.Models.DTO
{
    public class CreateTourProgramDTO
    {
        public string Name { get; set; }
        public List<CreateDayDTO> Days { get; set; }
    }
}
