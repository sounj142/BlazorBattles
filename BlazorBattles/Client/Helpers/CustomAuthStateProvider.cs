using System.Security.Claims;
using System.Threading.Tasks;
using BlazorBattles.Client.Services;
using BlazorBattles.Shared.DTOs;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBattles.Client.Helpers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IBananaService _bananaService;

        public CustomAuthStateProvider(ILocalStorageService localStorage, 
            IBananaService bananaService)
        {
            _localStorage = localStorage;
            _bananaService = bananaService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(LocalStorageNames.AccessToken);
            var userInfo = await _localStorage.GetItemAsync<UserDto>(LocalStorageNames.UserInfo);

            AuthenticationState authenticationState;
            if (string.IsNullOrWhiteSpace(token) || userInfo == null)
            {
                authenticationState = new AuthenticationState(new ClaimsPrincipal());
            }
            else
            {
                var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, userInfo.UserName),
                        new Claim(ClaimTypes.Email, userInfo.Email),
                        new Claim(ClaimTypes.NameIdentifier, userInfo.Id),
                    }, "Jwt");
                authenticationState = new AuthenticationState(new ClaimsPrincipal(identity));

                InitializeServicesData();
            }

            return authenticationState;
        }

        public void NotifyAuthenticationChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void InitializeServicesData()
        {
            _bananaService.GetBananasCount();
        }
    }
}
