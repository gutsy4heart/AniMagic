using AniMagic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //modelBuilder.ApplyConfiguration(new CartoonConfiguration());
        //modelBuilder.ApplyConfiguration(new EpisodeConfiguration());
        //modelBuilder.ApplyConfiguration(new CommentConfiguration());
        //modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
        //modelBuilder.ApplyConfiguration(new RatingConfiguration());
        //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);

        // Связи многие ко многим (например, Favorite)
        modelBuilder.Entity<Favorite>()
            .HasKey(f => new { f.UserId, f.CartoonId });

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId);

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Cartoon)
            .WithMany(c => c.Favorites)
            .HasForeignKey(f => f.CartoonId);

        // Связи многие ко многим (например, Rating)
        modelBuilder.Entity<Rating>()
            .HasKey(r => new { r.UserId, r.CartoonId });

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Cartoon)
            .WithMany(c => c.Ratings)
            .HasForeignKey(r => r.CartoonId);

        // Связи многие к одному (например, Comment)
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Cartoon)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.CartoonId);
    }

}
