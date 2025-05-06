using Microsoft.AspNetCore.Identity;

namespace WebApi.Models.Entity
{
    public class Client : IdentityUser
    {
       // public string Id {  get; set; }
        public string Name { get; set; }
        //public string Contact { get; set; }
        public int YearOfBirth { get; set; }
        public ICollection<TourClients> TourClients { get; set; }
    }
}
