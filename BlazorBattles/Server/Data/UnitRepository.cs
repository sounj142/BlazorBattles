using BlazorBattles.Server.Data.Interfaces;
using BlazorBattles.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Data
{
    public class UnitRepository : IUnitRepository
    {
        private readonly DataContext _dataContext;

        public UnitRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> GetUnit(int id)
        {
            return await _dataContext.Units.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Unit>> GetUnits()
        {
            return await _dataContext.Units.ToListAsync();
        }

        public void Add(Unit unit)
        {
            unit.Id = 0;
            _dataContext.Units.Add(unit);
        }

        public void Update(Unit unit)
        {
            _dataContext.Update(unit);
        }

        public void Delete(Unit unit)
        {
            _dataContext.Remove(unit);
        }
    }
}
