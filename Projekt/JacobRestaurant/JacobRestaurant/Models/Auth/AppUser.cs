using Microsoft.AspNetCore.Identity;

namespace JacobRestaurant.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
