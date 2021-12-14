using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBattles.Shared.ViewModels
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(16, ErrorMessage = "Your user name is too long(16 characters max).")]
        public string UserName { get; set; }
        public string Bio { get; set; }
        [Required, StringLength(64, MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Start unit is required")]
        public int StartUnitId { get; set; } = 1;
        [Required, Range(0, 1000, ErrorMessage = "Please choose a number between 0 and 1000.")]
        public int Bananas { get; set; } = 100;
        public DateTime DateOfBirth { get; set; } = DateTime.Today;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Only confirmed users can play!")]
        public bool IsConfirmed { get; set; } = true;
    }
}
