using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DotNetCoreReactShop.Models
{
    public class User: IdentityUser
    {
        public string GivenName { get; set; }
    }
}
