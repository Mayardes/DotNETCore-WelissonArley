using AutoMapper;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Domain.Entities;

namespace MyBookOfRecipes.Application.Mappings.UserMapping
{
    public class RequestToDomainMapping : Profile
    {
        public RequestToDomainMapping()
        {
            CreateMap<RegisterUserRequestDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
