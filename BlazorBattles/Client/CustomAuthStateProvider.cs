using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBattles.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _localStorage.GetItemAsync<bool>("IsAuthenticated"))
            {
                var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, "Hoang")
                    }, "test authentication type");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public void NotifyAuthenticationChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
