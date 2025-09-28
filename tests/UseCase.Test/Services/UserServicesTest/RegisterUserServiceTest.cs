using CommonTestUtilities.Mapper.User.RequestToDomain;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests.User;
using FluentAssertions;
using Microsoft.Extensions.Options;
using MyBookOfRecipes.Application.Cryptography;
using MyBookOfRecipes.Application.Exceptions;
using MyBookOfRecipes.Application.Services.UserServices;
using MyBookOfRecipes.Application.ValidatorMessages.UserValidatorMessage;

namespace UseCase.Test.Services.UserServicesTest;

public class RegisterUserServiceTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var requestDto = RegisterUserRequestBuilder.Build();
        var register = CreateRegisterUserService();
        
        //Act
        var result = await register.RegisterAsync(requestDto);
        
        //Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(requestDto.Name);
    }

    [Fact]
    public async Task Error_Name_Empty()
    {
        //Arrange
        var requestDto = RegisterUserRequestBuilder.Build();
        requestDto.Name = string.Empty;
        var register = CreateRegisterUserService();
        
        //Act
        Func<Task> act = async () => await register.RegisterAsync(requestDto);
        
        //Assert
        (await act.Should().ThrowAsync<ValidationException>())
            .Where(e => e.ErrorMessage.Contains(RegisterUserValidatorMessage.NAME_EMPTY) && e.ErrorMessage.Count == 1);
    }
    
    [Fact]
    public async Task Error_Email_Already_Exists()
    {
        //Arrange
        var requestDto = RegisterUserRequestBuilder.Build();
        var register = CreateRegisterUserService(requestDto.Email);
        
        //Act
        Func<Task> act = async() => await register.RegisterAsync(requestDto);
        
        //Assert
        (await act.Should().ThrowAsync<ValidationException>())
            .Where(x => x.ErrorMessage.Count == 1 && x.ErrorMessage.Contains(RegisterUserValidatorMessage.EMAIL_EXISTIS));
    }
    private RegisterUserService CreateRegisterUserService(string? email = null)
    {
        var mapper = RequestToDomainBuilder.Build();
        var encripterConfig = new EncripterConfig()
        {
            Key = "abc123"
        };
        var options = Options.Create(encripterConfig);
        var unitOfWorkMock = UnitOfWorkBuilder.Build();
        var repositoryMock = RepositoryWriteOnlyBuilder.Build();
        var repositoryReadOnlyRepositoryMock = new RepositoryReadOnlyBuilder();

        if (!string.IsNullOrEmpty(email))
        {
            repositoryReadOnlyRepositoryMock.IsExistActiveUserWithEmail((email));
        }
        
        return new RegisterUserService(mapper: mapper, repositoryMock, repositoryReadOnlyRepositoryMock.Build(), unitOfWorkMock, encripterOption: options);
    }
}