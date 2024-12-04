using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Application.Services;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Extensions;
using SannoisWorship.Infrastructure.Repositories.Interfaces;

namespace SannoisWorship.Application.Tests;

public class ChantServiceTests
{

    private readonly Mock<IChantRepository> _chantRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
    private readonly IChantService _chantService;


    public ChantServiceTests()
    {
        // Mocks
        _chantRepositoryMock = new Mock<IChantRepository>();
        _mapperMock = new Mock<IMapper>();
        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();


        // Simuler un HttpContext avec un utilisateur connecté
        var context = new DefaultHttpContext();
        context.User = new System.Security.Claims.ClaimsPrincipal(
            new System.Security.Claims.ClaimsIdentity(
                new[] { new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "TestUser") }
            )
        );
        _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(context);


        // Service à tester
        _chantService = new ChantService(
            _chantRepositoryMock.Object,
            _mapperMock.Object,
            _httpContextAccessorMock.Object
        );
    }


    [Fact]
    public async Task AddChantAsync_Should_Call_Repository_With_Correct_Data()
    {
        // Arrange
        var chantDto = new ChantDTO
        {
            Titre = "Chant de Test",
            Tonalite = "Do",
            Auteur = "Auteur un test."
        };

        var chantEntity = new Chant
        {
            Titre = chantDto.Titre,
            Tonalite = chantDto.Tonalite,
            Auteur = chantDto.Auteur,
            DateCreation = default,
            CreatedBy = "TestUser"
        };

        // Configurer AutoMapper pour mapper ChantDTO -> Chant
        _mapperMock.Setup(m => m.Map<Chant>(chantDto)).Returns(chantEntity);

        // Act
        await _chantService.AddChantAsync(chantDto);

        // Assert
        _mapperMock.Verify(m => m.Map<Chant>(chantDto), Times.Once);
        _chantRepositoryMock.Verify(r => r.AddAsync(It.Is<Chant>(c =>
            c.Titre == chantDto.Titre &&
            c.Tonalite == chantDto.Tonalite &&
            c.Auteur == chantDto.Auteur &&
            c.CreatedBy == "TestUser"
        )), Times.Once);
    }

}
