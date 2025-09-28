using Moq;
using MyBookOfRecipes.Domain.Repositories.UserRepository;

namespace CommonTestUtilities.Repositories;

public class RepositoryWriteOnlyBuilder
{
    public static IUserWriteRepository Build()
    {
        var mock = new Mock<IUserWriteRepository>();
        return mock.Object;
    }
}