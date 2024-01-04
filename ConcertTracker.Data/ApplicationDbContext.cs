using ConcertTracker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConcertTracker.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>().ToTable("Users");
    }

    public DbSet<BandEntity> Bands {get; set;} = null!;
    public DbSet<VenueEntity> Venues {get; set;} = null!;
}