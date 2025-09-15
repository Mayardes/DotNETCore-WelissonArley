using Bogus;
using CommonTestUtilities.Requests.User;
using MyBookOfRecipes.Application.Validators.UserValidator;

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

            //Assert
            Assert.True(result.IsValid);
        }
    }
}
