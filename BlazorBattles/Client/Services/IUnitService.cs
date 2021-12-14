using BlazorBattles.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IUnitService
    {
        IList<UserUnitDto> MyUnits { get; }
        IList<UnitDto> Units { get; }

        void AddToMyUnits(int unitId);
        void AddToMyUnits(UnitDto unit);
        UnitDto FindUnit(int unitId);
        string GetUnitImage(UnitDto unit);
        Task LoadUnits();
    }
}