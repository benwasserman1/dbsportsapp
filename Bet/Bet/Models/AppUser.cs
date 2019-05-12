using System;
using Microsoft.AspNetCore.Identity;

namespace Bet.Models
{
    public class AppUser: IdentityRole<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AppUser()
        {
        }
    }
}
