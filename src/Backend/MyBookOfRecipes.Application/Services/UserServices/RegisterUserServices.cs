using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Application.Validators.UserValidator;

namespace MyBookOfRecipes.Application.Services.UserServices
{
    public class RegisterUserServices
    {
        public RegisterUserResponseDTO Execute(RegisterUserRequestDTO request)
        {
            //Validate input request
            Validate(request);

            //Mapping values to Entity

            //Cryptography password

            //Save on Database

            return new RegisterUserResponseDTO()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
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
                var errorMessage = result.Errors.Select(x => x.ErrorMessage);
                throw new Exception(errorMessage.ToString());
            }
        }
    }
}
