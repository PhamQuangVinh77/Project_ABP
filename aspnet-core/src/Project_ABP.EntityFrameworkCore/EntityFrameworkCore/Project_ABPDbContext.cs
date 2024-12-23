using Microsoft.EntityFrameworkCore;
using Project_ABP.Entities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Project_ABP.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class Project_ABPDbContext :
    AbpDbContext<Project_ABPDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    // Management Tinh, Huyen, Xa
    public DbSet<Tinh> Tinhs { get; set; }
    public DbSet<Huyen> Huyens { get; set; }
    public DbSet<Xa> Xas { get; set; }
    // Management hospital
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<UserHospital> UserHospitals { get; set; }
    #endregion

    public Project_ABPDbContext(DbContextOptions<Project_ABPDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Tinh>(b =>
        {
            b.ToTable(Project_ABPConsts.DbTablePrefix + "Tinh", Project_ABPConsts.DbSchema);
            b.Property(t => t.TenTinh).HasColumnType("nvarchar(100)");
            b.Property(t => t.Cap).HasColumnType("nvarchar(50)");
            b.Property(t => t.IsDeleted).HasColumnType("bit");
        });

        builder.Entity<Huyen>(b =>
        {
            b.ToTable(Project_ABPConsts.DbTablePrefix + "Huyen", Project_ABPConsts.DbSchema);
            b.Property(t => t.TenHuyen).HasColumnType("nvarchar(100)");
            b.Property(t => t.Cap).HasColumnType("nvarchar(50)");
            b.Property(t => t.IsDeleted).HasColumnType("bit");
        });

        builder.Entity<Xa>(b =>
        {
            b.ToTable(Project_ABPConsts.DbTablePrefix + "Xa", Project_ABPConsts.DbSchema);
            b.Property(t => t.TenXa).HasColumnType("nvarchar(100)");
            b.Property(t => t.Cap).HasColumnType("nvarchar(50)");
            b.Property(t => t.IsDeleted).HasColumnType("bit");
        });
    }
}
