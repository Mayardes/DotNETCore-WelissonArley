using CommonTestUtilities.Requests.User;
using FluentAssertions;
using MyBookOfRecipes.Application.ValidatorMessages.UserValidatorMessage;
using MyBookOfRecipes.Application.Validators.UserValidator;
using Shouldly;

namespace Validation.Tests.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterUserValidator();

            //Act
            var request = RegisterUserRequestBuilder.Build();
            
            var result = validator.Validate(request);

            /*SHOULDLY*/
            result.ShouldNotBeNull();
            result.IsValid.ShouldBeTrue();

            /*FLUENT ASSERTIONS*/
            //Assert
            //result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Name_Empty()
        {   
            //Arrange
            var validator = new RegisterUserValidator();

            //Act
            var request = RegisterUserRequestBuilder.Build();
            request.Name = string.Empty;

            var result = validator.Validate(request);

            //Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(RegisterUserValidatorMessage.NAME_EMPTY));
        }

        [Fact]
        public void Error_Email_Empty()
        {
            //Arrange
            var validator = new RegisterUserValidator();

            //Act
            var request = RegisterUserRequestBuilder.Build();
            request.Email = string.Empty;

            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(RegisterUserValidatorMessage.EMAIL_EMPTY));
        }

        [Fact]
        public void Error_Email_Invalid()
        {
            //Arrange
            var validator = new RegisterUserValidator();

            //Act
            var request = RegisterUserRequestBuilder.Build();
            request.Email = "mayardes.oliveira.com.br"; //Example invalid email
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(RegisterUserValidatorMessage.EMAIL_VALID));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(3)]
        [InlineData(1)]
        [InlineData(4)]
        public void Error_Password_Invalid(int passwordLength)
        {
            //Assert
            var validator = new RegisterUserValidator();

            //Act
            var request = RegisterUserRequestBuilder.Build(passwordLength);

            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
