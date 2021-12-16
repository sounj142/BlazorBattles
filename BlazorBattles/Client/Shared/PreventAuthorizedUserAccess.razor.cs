using Microsoft.AspNetCore.Components;

namespace BlazorBattles.Client.Shared
{
    public partial class PreventAuthorizedUserAccess
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string RedirectToUrl { get; set; } = "/";
    }
}
