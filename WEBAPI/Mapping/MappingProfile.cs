using AutoMapper;
using WebApi.Models.Entity;
using WebApi.Models.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tour, TourDTOCreate>();
        CreateMap<TourDTOCreate, Tour>();
    }
}
