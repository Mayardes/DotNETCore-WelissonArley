using AutoMapper;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Application.Mappings.UserMapping;

namespace CommonTestUtilities.Mapper.User.RequestToDomain;

public class RequestToDomainBuilder
{
    public static IMapper Build()
    {
        return new MapperConfiguration(option =>
        {
            option.AddProfile(typeof(RequestToDomainMapping));
            option.AddProfile(typeof(DomainToResponseMapping));
        }).CreateMapper();
    }
}