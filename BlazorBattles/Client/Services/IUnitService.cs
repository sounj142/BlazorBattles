using BlazorBattles.Shared;
using System.Collections.Generic;

namespace BlazorBattles.Client.Services
{
    public interface IUnitService
    {
        IList<UserUnit> MyUnits { get; }
        IList<Unit> Units { get; }

        void AddToMyUnits(int unitId);
        void AddToMyUnits(Unit unit);
        Unit FindUnit(int unitId);
        string GetUnitImage(Unit unit);
    }
}