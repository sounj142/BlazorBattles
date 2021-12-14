using BlazorBattles.Server.Data.Interfaces;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private IUnitRepository _unitRepository;
        public IUnitRepository UnitRepository => _unitRepository ?? (_unitRepository = new UnitRepository(_dataContext));
        
        public async Task<bool> Complete()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _dataContext.ChangeTracker.HasChanges();
        }
    }
}
