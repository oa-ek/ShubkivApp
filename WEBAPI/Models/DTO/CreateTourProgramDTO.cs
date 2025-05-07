namespace WebApi.Models.DTO
{
    public class CreateTourProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CreateDayDTO> Days { get; set; }
    }
}
