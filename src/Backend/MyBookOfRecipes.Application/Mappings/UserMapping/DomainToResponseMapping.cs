using AutoMapper;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Domain.Entities;

namespace MyBookOfRecipes.Application.Mappings.UserMapping
{
    public class DomainToResponseMapping : Profile
    {
        public DomainToResponseMapping()
        {
            CreateMap<User, RegisterUserResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
