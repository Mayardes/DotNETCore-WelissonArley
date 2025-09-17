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
            RuleFor(x => x.Name.Length).LessThanOrEqualTo(100).WithMessage(RegisterUserValidatorMessage.NAME_RULE);
            RuleFor(x => x.Email.Length).LessThanOrEqualTo(100).WithMessage(RegisterUserValidatorMessage.EMAIL_RULE);
            RuleFor(x => x.Email).NotEmpty().WithMessage(RegisterUserValidatorMessage.EMAIL_EMPTY);
            RuleFor(x => x.Password).NotEmpty().WithMessage(RegisterUserValidatorMessage.PASSWORD_EMPTY);

            When(user => !string.IsNullOrEmpty(user.Email), () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(RegisterUserValidatorMessage.EMAIL_VALID);
            });

            When(user => !string.IsNullOrEmpty(user.Password), () =>
            {
                RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(RegisterUserValidatorMessage.PASSWORD_RULE);
            });
        }
    }
}
