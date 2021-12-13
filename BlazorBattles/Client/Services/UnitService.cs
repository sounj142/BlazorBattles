using BlazorBattles.Shared;
using Blazored.Toast.Services;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBattles.Client.Services
{
    public class UnitService : IUnitService
    {
        private readonly IToastService _toastService;

        public UnitService(IToastService toastService)
        {
            _toastService = toastService;
        }

        public IList<Unit> Units { get; private set; } = new List<Unit>
        {
            new Unit { Id = 1, Title = "Knight", Attack = 10, Defence = 10, BananaCost = 100 },
            new Unit { Id = 2, Title = "Archer", Attack = 15, Defence = 5, BananaCost = 150 },
            new Unit { Id = 3, Title = "Mage", Attack = 20, Defence = 1, BananaCost = 200 },
        };
        public IList<UserUnit> MyUnits { get; private set; } = new List<UserUnit>();

        public void AddToMyUnits(int unitId)
        {
            var unit = Units.FirstOrDefault(u => u.Id == unitId);
            if (unit != null)
                AddToMyUnits(unit);
        }

        public void AddToMyUnits(Unit unit)
        {
            MyUnits.Add(new UserUnit { UnitId = unit.Id, HitPoints = unit.HitPoints, Unit = unit });
            _toastService.ShowSuccess($"{unit.Title} unit has been added", "Unit built!");
        }

        public Unit FindUnit(int unitId)
        {
            return Units.FirstOrDefault(u => u.Id == unitId);
        }

        public string GetUnitImage(Unit unit)
        {
            return unit.Title switch
            {
                "Knight" => "/icons/knight.png",
                "Archer" => "/icons/archer.png",
                "Mage" => "/icons/mage.png",
                _ => string.Empty
            };
        }
    }
}
