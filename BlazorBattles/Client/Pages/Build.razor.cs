using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Authorization;

namespace BlazorBattles.Client.Pages
{
    [Authorize]
    public partial class Build : ComponentBase
    {
        private int selectedUnitId = 1;

        [Inject]
        public IBananaService BananaService { get; set; }

        [Inject]
        public IUnitService UnitService { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private void BuildUnit()
        {
            var selectedUnit = UnitService.FindUnit(selectedUnitId);
            if (selectedUnit != null)
            {
                if (BananaService.EatBananas(selectedUnit.BananaCost))
                    UnitService.AddToMyUnits(selectedUnit);
                else
                    ToastService.ShowError("Not enough bananas", ":(");
            }
        }
    }
}
