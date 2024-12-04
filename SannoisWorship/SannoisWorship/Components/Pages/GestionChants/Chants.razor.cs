using Microsoft.AspNetCore.Components;

namespace SannoisWorship.Components.Pages.GestionChants
{
    public partial class Chants
    {
        #region  Injection
        private readonly NavigationManager _navigationManager;
        private readonly IChantService _chantService;
        #endregion

        private List<ChantDTO>? chants;
        public Chants(NavigationManager navigation, IChantService chantService)
        {
            _navigationManager = navigation;
            _chantService = chantService;
        }

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