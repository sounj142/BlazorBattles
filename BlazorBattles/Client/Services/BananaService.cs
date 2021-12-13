using System;

namespace BlazorBattles.Client.Services
{
    public class BananaService : IBananaService
    {
        public int Bananas { get; set; } = 1000;

        public event Action OnBananasChanged;

        public bool EatBananas(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Banana amount must be positive!");
            if (Bananas < amount) return false;

            Bananas -= amount;
            BananasChanged();
            return true;
        }

        public void AddBananas(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Banana amount must be positive!");

            Bananas += amount;

            BananasChanged();
        }

        private void BananasChanged() => OnBananasChanged?.Invoke();
    }
}
