using BlazorBattles.Server.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Data.Interfaces
{
    public interface IUnitRepository
    {
        Task<Unit> GetUnit(int id);
        Task<IList<Unit>> GetUnits();
        void Add(Unit unit);
        void Update(Unit unit);
        void Delete(Unit unit);
    }
}
