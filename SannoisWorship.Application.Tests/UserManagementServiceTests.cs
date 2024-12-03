using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Application.Services;
using SannoisWorship.Infrastructure.Extensions;

namespace SannoisWorship.Application.Tests;

public class UserManagementServiceTests
{

    private readonly Mock<IUserStore<IdentityUser>> _userStoreMock;
    private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
    private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
    private readonly IUserManagementService _service;
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
    public UserManagementServiceTests()
    {
        // Configuration des mocks
        _userStoreMock = new Mock<IUserStore<IdentityUser>>();
        _userManagerMock = new Mock<UserManager<IdentityUser>>(
            _userStoreMock.Object,
            null, null, null, null, null, null, null, null
        );
        _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
            new Mock<IRoleStore<IdentityRole>>().Object,
            null, null, null, null
        );

        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

        // Instanciation du service à tester
        _service = new UserManagementService(_userManagerMock.Object, _roleManagerMock.Object, _httpContextAccessorMock.Object);
    }


    [Fact]
    public async Task GetUsersWithRolesAsync_ReturnsCorrectUserList()
    {
        // Arrange
        var mockUsers = new List<IdentityUser>
        {
            new IdentityUser { Id = "1", Email = "user1@example.com", UserName = "User1" },
            new IdentityUser { Id = "2", Email = "user2@example.com", UserName = "User2" }
        }.ToAsyncQueryable();

        _userManagerMock.Setup(u => u.Users).Returns(mockUsers);

        _userManagerMock.Setup(u => u.GetRolesAsync(It.IsAny<IdentityUser>()))
            .ReturnsAsync((IdentityUser user) => user.UserName == "User1" ? new List<string> { "Admin" } : new List<string> { "User" });

        // Act
        var result = await _service.GetUsersWithRolesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, u => u.UserName == "User1" && u.Roles.Contains("Admin"));
        Assert.Contains(result, u => u.UserName == "User2" && u.Roles.Contains("User"));
    }

    [Fact]
    public async Task AddUserAsync_AddsUserSuccessfully()
    {
        // Arrange
        var newUser = new DTOs.CreateUserModel { UserName = "newUser", Email = "newuser@example.com", Password= "password123" };
        _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                        .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _service.CreateUserAsync(newUser);

        // Assert
        Assert.True(result.Succeeded);
        _userManagerMock.Verify(x => x.CreateAsync(It.Is<IdentityUser>(u => u.UserName == "newUser"), "password123"), Times.Once);
    }

    [Fact]
    public async Task AddRoleAsync_AddsRoleSuccessfully()
    {
        // Arrange
        var newRole = "Admin";
        _roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityRole>()))
                        .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _service.AddRoleAsync(newRole);

        // Assert
        Assert.True(result);
        _roleManagerMock.Verify(x => x.CreateAsync(It.Is<IdentityRole>(r => r.Name == "Admin")), Times.Once);
    }
}
