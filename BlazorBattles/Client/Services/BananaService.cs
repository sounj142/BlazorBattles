using System;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class BananaService : IBananaService
    {
        private readonly IAccountService _accountService;

        public int Bananas { get; private set; }

        public event Action OnBananasChanged;

        public BananaService(IAccountService accountService)
        {
            _accountService = accountService;
        }

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

        public async Task GetBananasCount()
        {
            var userInfo = await _accountService.GetUserInfo();
            Bananas = userInfo.Bananas;

            BananasChanged();
        }
    }
}
