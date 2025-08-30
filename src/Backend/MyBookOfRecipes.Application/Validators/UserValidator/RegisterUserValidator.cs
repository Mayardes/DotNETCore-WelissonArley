using FluentValidation;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;
using MyBookOfRecipes.Application.ValidatorMessages.UserValidatorMessage;

namespace MyBookOfRecipes.Application.Validators.UserValidator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequestDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(RegisterUserValidatorMessage.NAME_EMPTY);
            RuleFor(x => x.Email).NotEmpty().WithMessage(RegisterUserValidatorMessage.EMAIL_EMPTY);
            RuleFor(x => x.Email).EmailAddress().WithMessage(RegisterUserValidatorMessage.EMAIL_VALID);
            RuleFor(x => x.Password).NotEmpty().WithMessage(RegisterUserValidatorMessage.PASSWORD_EMPTY);
            RuleFor(x => x.Password.Length).GreaterThanOrEqualTo(6).WithMessage(RegisterUserValidatorMessage.PASSWORD_RULE);
        }
    }
}
