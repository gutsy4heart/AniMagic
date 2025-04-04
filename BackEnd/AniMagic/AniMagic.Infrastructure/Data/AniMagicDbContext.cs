using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniMagic.;

namespace AniMagic.Infrastructure.Data;

public class AniMagicDbContext : DbContext
{
    public AniMagicDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Cartoon> Cartoons { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        // Configure Role entity
        modelBuilder.Entity<Roles>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Roles>()
            .HasData(
                new Roles("Admin") { Id = Guid.NewGuid() },
                new Roles("User") { Id = Guid.NewGuid() }
            );

        // Configure User entity
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Cartoon entity
        modelBuilder.Entity<Cartoon>()
            .HasKey(c => c.Id);

        // Configure Favorite entity
        modelBuilder.Entity<Favorite>()
            .HasKey(f => new { f.UserId, f.CartoonId });

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId);

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Cartoon)
            .WithMany()
            .HasForeignKey(f => f.CartoonId);

        // Configure Rating entity
        modelBuilder.Entity<Rating>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Cartoon)
            .WithMany()
            .HasForeignKey(r => r.CartoonId);

        // Configure Comment entity
        modelBuilder.Entity<Comment>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Cartoon)
            .WithMany()
            .HasForeignKey(c => c.CartoonId);
    }
}


