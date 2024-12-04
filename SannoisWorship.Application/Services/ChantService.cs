using AutoMapper;
using Microsoft.AspNetCore.Http;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;
using SannoisWorship.Core.Entities;
using SannoisWorship.Infrastructure.Repositories.Interfaces;
using System;

namespace SannoisWorship.Application.Services;

public class ChantService : IChantService
{
    private readonly IChantRepository _chantRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ChantService(IChantRepository chantRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _chantRepository = chantRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task AddChantAsync(ChantDTO chantDto)
    {
       
        var chant = _mapper.Map<Chant>(chantDto);

        // Récupérer le nom de l'utilisateur connecté
        var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        // Remplir CreatedBy
        chant.CreatedBy = userName ?? "System";

        await _chantRepository.AddAsync(chant);
    }

    public async Task DeleteChantAsync(int id)
    {
        await _chantRepository.DeleteAsync(id);
    }

    public async Task<List<ChantDTO>> GetAllChantsAsync()
    {
        var chants = await _chantRepository.GetAllAsync();

        return _mapper.Map<List<ChantDTO>>(chants);

    }

    public async Task<ChantDTO?> GetChantByIdAsync(int id)
    {
       var chant = await _chantRepository.GetByIdAsync(id);


       return _mapper.Map<ChantDTO?>(chant);
    }

    public async Task UpdateChantAsync(ChantDTO chantDto)
    {
        var chant = _mapper.Map<Chant>(chantDto);

        await _chantRepository.UpdateAsync(chant);
    }
}
