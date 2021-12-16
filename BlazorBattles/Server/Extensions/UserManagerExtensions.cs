using BlazorBattles.Server.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> GetCurrentUser(this UserManager<AppUser> userManager, ClaimsPrincipal claimsPrincipal)
        {
            AppUser user = null;
            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
                }
            }
            return user;
        }
    }
}
