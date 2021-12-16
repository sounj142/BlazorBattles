using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BlazorBattles.Shared.ViewModels;
using BlazorBattles.Client.Services;
using Blazored.Toast.Services;
using BlazorBattles.Client.Helpers;
using System.Net.Http;

namespace BlazorBattles.Client.Shared
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public IToastService Toast { get; set; }

        private UserLogin model = new UserLogin();

        private async Task HandleLogin()
        {
            try
            {
                var token = await AccountService.RequestToken(model);

                if (string.IsNullOrWhiteSpace(token))
                {
                    Toast.ShowError("Invalid username or password", "Login failed");
                    return;
                }

                await LocalStorage.SetItemAsync(LocalStorageNames.AccessToken, token);

                var userInfo = await AccountService.GetUserInfo();
                if (userInfo == null)
                {
                    Toast.ShowError("Error occurred when getting user information from server. Try again later.", "Login failed");
                    await LocalStorage.RemoveItemAsync(LocalStorageNames.AccessToken);
                    return;
                }

                await LocalStorage.SetItemAsync(LocalStorageNames.UserInfo, userInfo);

                ((CustomAuthStateProvider)AuthenticationStateProvider).NotifyAuthenticationChanged();
            }
            catch(HttpRequestException ex)
            {
                System.Console.Error.WriteLine(ex.Message);
                await LocalStorage.RemoveItemAsync(LocalStorageNames.AccessToken);
                await LocalStorage.RemoveItemAsync(LocalStorageNames.UserInfo);
            }
        }
    }
}
