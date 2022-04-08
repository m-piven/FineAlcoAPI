using AutoMapper;
using FineAlcoAPI.Entities;
using FineAlcoAPI.Models;

namespace FineAlcoAPI
{
    public class BarMappingProfile : Profile
    {
        public BarMappingProfile()
        {
            CreateMap<Bar, BarDto>()
            .ForMember(x => x.City, c => c.MapFrom(x => x.Address.City))
            .ForMember(x => x.Street, c => c.MapFrom(x => x.Address.Street))
            .ForMember(x => x.PostalCode, c => c.MapFrom(x => x.Address.PostalCode));

            CreateMap<AlcoDrink, AlcoDrinkDto>();

            CreateMap<CreateBarDto, Bar>()
                .ForMember(x=>x.Address, c=>c.MapFrom(dto=> new Address()
                { City = dto.City, Street = dto.Street, PostalCode=dto.PostalCode }));

            CreateMap<AlcoDrinkDto, AlcoDrink>();
        }
    }
}
