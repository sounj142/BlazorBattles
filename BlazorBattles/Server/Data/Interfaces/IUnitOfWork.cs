using System.Threading.Tasks;

namespace BlazorBattles.Server.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IUnitRepository UnitRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
