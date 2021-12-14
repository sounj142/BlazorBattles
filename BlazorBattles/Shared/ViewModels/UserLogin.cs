using System.ComponentModel.DataAnnotations;

namespace BlazorBattles.Shared.ViewModels
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
