using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BlazorBattles.Shared.ViewModels;

namespace BlazorBattles.Client.Shared
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        private UserLogin model = new UserLogin();

        private async Task HandleLogin()
        {
            await LocalStorage.SetItemAsync("IsAuthenticated", true);
            ((CustomAuthStateProvider)AuthenticationStateProvider).NotifyAuthenticationChanged();
        }
    }
}
