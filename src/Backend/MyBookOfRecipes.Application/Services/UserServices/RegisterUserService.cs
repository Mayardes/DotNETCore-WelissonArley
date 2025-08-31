using AutoMapper;
using MyBookOfRecipes.Application.Cryptography;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Application.Exceptions;
using MyBookOfRecipes.Application.Validators.UserValidator;
using MyBookOfRecipes.Domain.Entities;

namespace MyBookOfRecipes.Application.Services.UserServices
{
    public class RegisterUserService(IMapper mapper) : IRegisterUserService
    {
        public Task<RegisterUserResponseDTO>RegisterAsync(RegisterUserRequestDTO request)
        {
            //Validate input request
            Validate(request);

            //Mapping values to Entity
            var user = mapper.Map<User>(request);

            //Cryptography password
            user.Password = PasswordEncripter.Encrypt(user.Password);

            //Save on Database

            var result = mapper.Map<RegisterUserResponseDTO>(user);

            return Task.FromResult(result);
        }

        //Library validators avaliables at the moment - 30/08/2025
        //1.Data Annotation - Native .NET
        //2.Fluent Validation - But does not have support anymore, more simples to use.
        //3.Validot - has high performace.
        //4.CSLA.NET - indicate for business more complex, with validation  tightly coupled to logic.
        public static void Validate(RegisterUserRequestDTO request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);
            
            if(!result.IsValid)
            {
                var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(errorMessage);
                //throw new Exception();
            }
        }
    }
}
