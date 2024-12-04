using Microsoft.AspNetCore.Components;
using SannoisWorship.Application.DTOs;
using SannoisWorship.Application.Interfaces;

namespace SannoisWorship.Client.Pages
{
    public partial class GestionChant
    {

        #region  Injection
        private readonly NavigationManager _navigationManager;
        private readonly IChantService _chantService;
        #endregion


        public GestionChant(NavigationManager navigationManager,IChantService chantService)
        {
            _navigationManager = navigationManager;
            _chantService = chantService;
        }
        private List<ChantDTO>? chants;

        protected override async Task OnInitializedAsync()
        {
            chants = await _chantService.GetAllChantsAsync();

        }


        private void OnCreateNewChant()
        {
            _navigationManager.NavigateTo("/create-chant");
        }

    }
}