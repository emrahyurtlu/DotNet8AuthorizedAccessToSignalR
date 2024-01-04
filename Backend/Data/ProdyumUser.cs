using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;

namespace Net8Identity.Data
{
    public class ProdyumUser: IdentityUser
    {
        public string? CustomProperty { get; set; }
    }
}
