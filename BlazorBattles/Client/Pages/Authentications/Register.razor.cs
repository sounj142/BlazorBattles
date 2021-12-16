using BlazorBattles.Client.Services;
using BlazorBattles.Shared.ViewModels;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages.Authentications
{
    public partial class Register : ComponentBase
    {
        private UserRegister model = new UserRegister();

        [Inject]
        public IUnitService UnitService { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IToastService Toast { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private async Task HandleRegistration()
        {
            var registerResult = await AccountService.Register(model);
            if (registerResult.Succeeded)
            {
                Toast.ShowSuccess("Registration successful!");
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Toast.ShowError(registerResult.Message, "Registration fail");
            }
        }
    }
}
