using BlazorBattles.Client.Services;
using BlazorBattles.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Pages.Authentication
{
    public partial class Register : ComponentBase
    {
        private UserRegister model = new UserRegister();

        [Inject]
        public IUnitService UnitService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async Task HandleRegistration()
        {
            await JSRuntime.InvokeVoidAsync("console.log", model);
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(model));

            NavigationManager.NavigateTo("/login");
        }
    }
}
