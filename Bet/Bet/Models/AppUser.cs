using System;
using Microsoft.AspNetCore.Identity;

namespace Bet.Models
{
    public class AppUser: IdentityRole<int>
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public bool Authenticated { get; set; }

        public AppUser()
        {
        }
    }
}
