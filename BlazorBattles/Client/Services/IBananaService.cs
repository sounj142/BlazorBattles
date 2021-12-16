using System;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IBananaService
    {
        int Bananas { get; }

        event Action OnBananasChanged;

        bool EatBananas(int amount);
        void AddBananas(int amount);
        Task GetBananasCount();
    }
}