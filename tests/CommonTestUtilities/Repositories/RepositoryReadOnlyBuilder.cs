using Moq;
using MyBookOfRecipes.Domain.Repositories.UserRepository;

namespace CommonTestUtilities.Repositories;

public class RepositoryReadOnlyBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;
    
    /// <summary>
    /// </summary>
    public RepositoryReadOnlyBuilder() => _repository = new Mock<IUserReadOnlyRepository>();
    public IUserReadOnlyRepository Build() => _repository.Object;

    public void IsExistActiveUserWithEmail(string email)
    { 
        _repository.Setup(x => x.IsExistActiveUserWithEmail(email)).ReturnsAsync(true);
    }
}