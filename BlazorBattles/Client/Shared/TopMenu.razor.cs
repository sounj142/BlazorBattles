using BlazorBattles.Client.Helpers;
using BlazorBattles.Client.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Shared
{
    public partial class TopMenu : ComponentBase, IDisposable
    {
        [Inject]
        public IBananaService BananaService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            BananaService.OnBananasChanged += StateHasChanged;
        }

        public void Dispose()
        {
            BananaService.OnBananasChanged -= StateHasChanged;
        }

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync(LocalStorageNames.AccessToken);
            await LocalStorage.RemoveItemAsync(LocalStorageNames.UserInfo);

            ((CustomAuthStateProvider)AuthenticationStateProvider).NotifyAuthenticationChanged();
            NavigationManager.NavigateTo("/");
        }
    }
}
