using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorBattles.Client.Shared
{
    public partial class TopMenu : ComponentBase, IDisposable
    {
        [Inject]
        public IBananaService BananaService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            BananaService.OnBananasChanged += StateHasChanged;
        }

        public void Dispose()
        {
            BananaService.OnBananasChanged -= StateHasChanged;
        }
    }
}
