using BlazorBattles.Shared.DTOs;
using BlazorBattles.Shared.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RequestToken(UserLogin userLogin)
        {
            var tokenRequestData = new TokenEndpointRequest
            {
                ClientId = "BlazorBattles.Client",
                GrantType = "password",
                Scope = "BlazorBattles.ServerAPI openid profile",
                Username = userLogin.UserName,
                Password = userLogin.Password
            };
            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", tokenRequestData.ClientId),
                new KeyValuePair<string, string>("scope", tokenRequestData.Scope),
                new KeyValuePair<string, string>("grant_type", tokenRequestData.GrantType),
                new KeyValuePair<string, string>("username", tokenRequestData.Username),
                new KeyValuePair<string, string>("password", tokenRequestData.Password)
            });
            var response = await _httpClient.PostAsync("connect/token", requestContent);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenEndpointResult>();
                return tokenResponse.AccessToken;
            }

            return null;
        }

        public async Task<UserDto> GetUserInfo()
        {
            var userDto = await _httpClient.GetFromJsonAsync<UserDto>("api/accounts/user-info");
            return userDto;
        }

        public async Task<Result<UserDto>> Register(UserRegister model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/accounts/register", model);
            return await response.Content.ReadFromJsonAsync<Result<UserDto>>();
        }
    }
}
