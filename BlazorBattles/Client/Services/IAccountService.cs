using BlazorBattles.Shared.DTOs;
using BlazorBattles.Shared.ViewModels;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IAccountService
    {
        Task<string> RequestToken(UserLogin userLogin);
        Task<UserDto> GetUserInfo();
        Task<Result<UserDto>> Register(UserRegister model);
    }
}
