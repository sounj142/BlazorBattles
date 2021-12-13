using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBattles.Client.Pages
{
    public partial class Army : ComponentBase
    {
        [Inject]
        public IUnitService UnitService { get; set; }
    }
}
