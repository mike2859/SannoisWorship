using Microsoft.AspNetCore.Components;

namespace SannoisWorship.Components.Pages.Admin
{
    public partial class CreateUser
    {
        [SupplyParameterFromForm]
        public CreateUserModel UserModel { get; set; } = new();

        private List<string> roles = new();
        private string? message;

        private readonly NavigationManager _navigationManager;
        private readonly IUserManagementService _userManagementService;
        public CreateUser(NavigationManager navigationManager, IUserManagementService userManagementService)
        {
            _navigationManager = navigationManager;
            _userManagementService = userManagementService;
        }
        protected override async Task OnInitializedAsync()
        {
            roles = await _userManagementService.GetRolesAsync();
        }

        private async Task HandleSubmit()
        {
            var result = await _userManagementService.CreateUserAsync(UserModel);
            if (result.Succeeded)
            {
                _navigationManager.NavigateTo("/users");
            }
            else
            {
                message = string.Join(", ", result.Errors.Select(e => e.Description));
            }
        }


    }
}