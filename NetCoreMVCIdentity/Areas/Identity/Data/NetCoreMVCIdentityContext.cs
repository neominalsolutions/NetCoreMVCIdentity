using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCIdentity.Areas.Identity.Data;

namespace NetCoreMVCIdentity.Data;

public class NetCoreMVCIdentityContext : IdentityDbContext<NetCoreMVCIdentityUser, IdentityUserRole, string>
{
    public NetCoreMVCIdentityContext(DbContextOptions<NetCoreMVCIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
