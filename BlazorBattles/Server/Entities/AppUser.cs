using Microsoft.AspNetCore.Identity;
using System;

namespace BlazorBattles.Server.Entities
{
    public class AppUser : IdentityUser
    {
        public string Bio { get; set; }
        public int Bananas { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
