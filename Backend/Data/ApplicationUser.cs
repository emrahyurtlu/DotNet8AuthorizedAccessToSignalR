using Microsoft.AspNetCore.Identity;

namespace Net8Identity.Data;

public class ApplicationUser : IdentityUser
{
    public string? CustomProperty { get; set; }
}
