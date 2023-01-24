using Microsoft.AspNetCore.Identity;

namespace AnyarMVC.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
