using FreelaDev.MsProjects.Application.Commands.Users.Create;
using FreelaDev.MsProjects.Application.Services.Authentication;
using FreelaDev.MsProjects.Core.Abstractions;
using FreelaDev.MsProjects.Core.Enumerations;
using FreelaDev.MsProjects.Core.Primitives;
using FreelaDev.MsProjects.Core.Repositories;
using NSubstitute;

namespace FreelaDev.MsProjects.Tests;

public class CreateUserCommandTests
{

    /// <summary>
    /// Checks if the <see cref="CreateUserCommandHandler"/> will return a result error when an e-mail is already taken.
    /// </summary>
    [Fact]
    public async Task HandlerShouldReturnFailWhenEmailsAlreadyTaken()
    {
        var createUserCommand = new CreateUserCommand("João", "Back", "back@mail.com", "123", ERole.Admin, new());
        // uow mocks
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        unitOfWorkMock.UserRepository.Returns(userRepositoryMock);
        unitOfWorkMock.UserRepository.IsEmailUnique(Arg.Is<string>(o => o == createUserCommand.Email)).Returns(false);
        // auth mock
        var jwtProviderMock = Substitute.For<IJwtProvider>();
        var createUserCommandHandler = new CreateUserCommandHandler(unitOfWorkMock, jwtProviderMock);
        var result = await createUserCommandHandler.Handle(createUserCommand, CancellationToken.None);
        Assert.Equal(DomainErrors.User.EmailNotUnique, result.Error);
    }
    
    /// <summary>
    /// Checks if the <see cref="CreateUserCommandHandler"/> will return a result error when no skills are informed.
    /// </summary>
    [Fact]
    public async Task HandlerShouldReturnFailWhenSkillsEmpty()
    {
        var createUserCommand = new CreateUserCommand("João", "Back", "back3@mail.com", "123", ERole.Admin, new());
        // uow mocks
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        unitOfWorkMock.UserRepository.Returns(userRepositoryMock);
        unitOfWorkMock.UserRepository.IsEmailUnique(Arg.Is<string>(o => o == createUserCommand.Email)).Returns(true);
        // auth mock
        var jwtProviderMock = Substitute.For<IJwtProvider>();
        // test
        var createUserCommandHandler = new CreateUserCommandHandler(unitOfWorkMock, jwtProviderMock);
        var result = await createUserCommandHandler.Handle(createUserCommand, CancellationToken.None);
        Assert.Equal(DomainErrors.User.SkillsIsEmpty, result.Error);
    }
}