namespace SannoisWorship.Components.Pages.Admin
{
    public partial class Users
    {
        #region  Injection
        private readonly IUserManagementService _userManagementService;

        #endregion


        private List<UserWithRolesDto>? users;
        public Users(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        protected override async Task OnInitializedAsync()
        {
            users = await _userManagementService.GetUsersWithRolesAsync();
        }
    }
}