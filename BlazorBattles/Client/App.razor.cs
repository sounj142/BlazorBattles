using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorBattles.Client
{
    public partial class App
    {
        [Inject]
        public IUnitService UnitService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await UnitService.LoadUnits();
            await base.OnInitializedAsync();
        }
    }
}
