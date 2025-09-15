using Bogus;
using MyBookOfRecipes.Application.DTO.Request.User.RegisterUser;

namespace CommonTestUtilities.Requests.User
{
    public class RegisterUserRequestBuilder
    {
        public static RegisterUserRequestDTO Builder()
        {
            var faker = new Faker<RegisterUserRequestDTO>("en")
                .RuleFor(x => x.Name, (f) => f.Person.FirstName)
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.Name))
                .RuleFor(x => x.Password, (f) => f.Internet.Password());

            return faker;
        }
    }
}
