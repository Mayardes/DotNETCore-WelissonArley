using Bogus;
using CommonTestUtilities.Requests.User;
using FluentAssertions;
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
            var request = RegisterUserRequestBuilder.Builder();
            
            var result = validator.Validate(request);

            /*SHOULDLY*/
            result.ShouldNotBeNull();
            result.IsValid.ShouldBeTrue();

            /*FLUENT ASSERTIONS*/
            //Assert
            //result.IsValid.Should().BeTrue();
        }
    }
}
