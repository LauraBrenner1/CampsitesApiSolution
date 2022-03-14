using Microsoft.EntityFrameworkCore;

namespace CampsitesApi.Data;

public class CampsiteDataContext : DbContext
{

    public virtual DbSet<Site>? Sites { get; set; }

    public CampsiteDataContext(DbContextOptions<CampsiteDataContext> options): base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Site>()
            .HasKey(k =>k.SiteId);

        modelBuilder.Entity<Site>()
            .Property(k => k.SiteId)
            .IsRequired()
            .HasMaxLength(10);

        modelBuilder.Entity<Site>()
            .Property(k => k.SiteName)
            .IsRequired()
            .HasMaxLength(200);
    }
}

public class Site
{
    public string SiteId { get; init; } = string.Empty;
    public string SiteName { get; init; } = string.Empty;
    public bool HasWater { get; init; } = false;
    public bool HasElectricalHookup { get; init; } = false;
    public bool IsLakeFront { get; init; } = false;

    public virtual IList<SiteBooking> Bookings { get; init; }
}

public class SiteBooking
{
    public int Id { get; init; }
    public string SiteId { get; init; } = string.Empty;

    public DateTime ReservationDate { get; init; }

    public int NumberOfDays { get; init; } = 1;
}
