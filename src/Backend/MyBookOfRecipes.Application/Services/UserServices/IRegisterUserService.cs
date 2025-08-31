using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;

namespace MyBookOfRecipes.Application.Services.UserServices
{
    public interface IRegisterUserService
    {
        Task<RegisterUserResponseDTO>RegisterAsync(RegisterUserRequestDTO request);
    }
}
