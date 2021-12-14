using BlazorBattles.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorBattles.Client.Pages
{
    [Authorize]
    public partial class Army : ComponentBase
    {
        [Inject]
        public IUnitService UnitService { get; set; }
    }
}
