using BlazorBattles.Shared.DTOs;
using Blazored.Toast.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class UnitService : IUnitService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _httpClient;

        public UnitService(IToastService toastService, HttpClient httpClient)
        {
            _toastService = toastService;
            _httpClient = httpClient;
        }

        public IList<UnitDto> Units { get; private set; } = new UnitDto[0];
        public IList<UserUnitDto> MyUnits { get; private set; } = new List<UserUnitDto>();

        public void AddToMyUnits(int unitId)
        {
            var unit = Units.FirstOrDefault(u => u.Id == unitId);
            if (unit != null)
                AddToMyUnits(unit);
        }

        public void AddToMyUnits(UnitDto unit)
        {
            MyUnits.Add(new UserUnitDto { UnitId = unit.Id, HitPoints = unit.HitPoints, Unit = unit });
            _toastService.ShowSuccess($"{unit.Title} unit has been added", "Unit built!");
        }

        public UnitDto FindUnit(int unitId)
        {
            return Units.FirstOrDefault(u => u.Id == unitId);
        }

        public string GetUnitImage(UnitDto unit)
        {
            return unit.Title switch
            {
                "Knight" => "/icons/knight.png",
                "Archer" => "/icons/archer.png",
                "Mage" => "/icons/mage.png",
                _ => string.Empty
            };
        }

        public async Task LoadUnits()
        {
            Units = await _httpClient.GetFromJsonAsync<IList<UnitDto>>("api/units");
        }
    }
}
