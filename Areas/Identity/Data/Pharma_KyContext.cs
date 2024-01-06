using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharma_Ky.Areas.Identity.Data;
using Pharma_Ky.Models;

namespace Pharma_Ky.Data;

public class Pharma_KyContext : IdentityDbContext<Pharma_KyUser>
{
    public Pharma_KyContext(DbContextOptions<Pharma_KyContext> options)
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
    public DbSet<Pharma_Ky.Models.Cosmetics> Cosmetics { get; set; } = default!;

    public DbSet<Pharma_Ky.Models.DevChid> DevChid { get; set; } = default!;

    public DbSet<Pharma_Ky.Models.MedicVits> MedicVits { get; set; } = default!;
}
