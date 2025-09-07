using AutoMapper;
using Microsoft.Extensions.Options;
using MyBookOfRecipes.Application.Cryptography;
using MyBookOfRecipes.Application.DTO.Request.User.GetUser;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.DTO.Response.User.GetUser;
using MyBookOfRecipes.Application.DTO.Response.User.RegisterUser;
using MyBookOfRecipes.Application.Exceptions;
using MyBookOfRecipes.Application.ValidatorMessages.UserValidatorMessage;
using MyBookOfRecipes.Application.Validators.UserValidator;
using MyBookOfRecipes.Domain.Entities;
using MyBookOfRecipes.Domain.Repositories.UserRepository;
using MyBookOfRecipes.Domain.UnitOfWork;

namespace MyBookOfRecipes.Application.Services.UserServices
{
    public class RegisterUserService(IMapper mapper, IUserWriteRepository repository, IUserReadOnlyRepository readRepository, IUnitOfWork unitOfWork, IOptions<EncripterConfig> encripterOption) : IRegisterUserService
    {
        private readonly EncripterConfig _encripterOption = encripterOption.Value;
        public async Task<RegisterUserResponseDTO>RegisterAsync(RegisterUserRequestDTO request)
        {
            //Validação de negócio
            var isEmailExists = await readRepository.IsExistActiveUserWithEmail(request.Email);

            //Validate input request
            Validate(request, isEmailExists);

            //Mapping values to Entity
            var user = mapper.Map<User>(request);

            //Cryptography password
            user.Password = PasswordEncripter.Encrypt(user.Password, _encripterOption.Key);

            //Save on Database
            await repository.CreateAsync(user);
            await unitOfWork.CommitAsyc();

            var result = mapper.Map<RegisterUserResponseDTO>(user);

            return result;
        }

        //Library validators avaliables at the moment - 30/08/2025
        //1.Data Annotation - Native .NET
        //2.Fluent Validation - But does not have support anymore, more simples to use.
        //3.Validot - has high performace.
        //4.CSLA.NET - indicate for business more complex, with validation  tightly coupled to logic.
        public static void Validate(RegisterUserRequestDTO request, bool isEmailExists)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if(isEmailExists)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure { ErrorMessage = RegisterUserValidatorMessage.EMAIL_EXISTIS });
                var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(errorMessage);
            }


            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(errorMessage);
                //throw new Exception();
            }
        }

        public async Task<IEnumerable<GetUserResponseDTO>> GetUserAsync(GetUserRequestDTO request)
        {
            var result = await readRepository.GetAsync(request);

            var response = mapper.Map<IEnumerable<GetUserResponseDTO>>(result);

            return response;
        }
    }
}
