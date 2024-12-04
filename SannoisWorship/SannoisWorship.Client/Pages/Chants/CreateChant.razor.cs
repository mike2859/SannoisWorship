using Microsoft.AspNetCore.Components;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;

namespace SannoisWorship.Client.Pages.Chants
{
    public partial class CreateChant
    {
        [SupplyParameterFromForm]
        public ChantDTO Chant { get; set; } = new();
        private readonly IChantService _chantService;

        public CreateChant(IChantService chantService)
        {
            _chantService = chantService;
        }

        private async Task HandleValidSubmit()
        {

            await _chantService.AddChantAsync(Chant);
            // Redirection ou notification
        }

        private void Cancel()
        {

        }
    }
}