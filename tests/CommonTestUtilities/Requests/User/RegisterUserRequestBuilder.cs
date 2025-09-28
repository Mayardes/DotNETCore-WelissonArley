using Bogus;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;

namespace CommonTestUtilities.Requests.User
{
    public class RegisterUserRequestBuilder
    {
        public static RegisterUserRequestDTO Builder(int passwordLength = 10)
        {
            var faker = new Faker<RegisterUserRequestDTO>("en")
                .RuleFor(x => x.Name, (f) => f.Person.FullName)
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.Name))
                .RuleFor(x => x.Password, (f) => f.Internet.Password(passwordLength));

            return faker;
        }
    }
}
