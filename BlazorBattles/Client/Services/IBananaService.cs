using System;

namespace BlazorBattles.Client.Services
{
    public interface IBananaService
    {
        int Bananas { get; set; }

        event Action OnBananasChanged;

        bool EatBananas(int amount);
        void AddBananas(int amount);
    }
}