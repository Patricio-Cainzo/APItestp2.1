using APItestp2._1.Models.Dtos;
using AutoMapper;

namespace APItestp2._1.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();
        }
    }
}
