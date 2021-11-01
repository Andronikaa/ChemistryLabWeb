using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace SQLServerBased.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChemicalElement, ChemicalElementDto>();
            CreateMap<Compound, CompoundDto>();
            CreateMap<CompoundForCreationDto, Compound>();
        }
    }
}
