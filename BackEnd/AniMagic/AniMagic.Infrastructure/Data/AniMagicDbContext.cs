using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniMagic.Domain.Models;

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
        // Configure Comment entity
        modelBuilder.Entity<Comment>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Cartoon)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.CartoonId)
            .HasConstraintName("FK_Comment_Cartoon");  // Указываем имя внешнего ключа

        // Configure Rating entity
        modelBuilder.Entity<Rating>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Rating>()
            .HasOne(r => r.Cartoon)
            .WithMany(c => c.Ratings)
            .HasForeignKey(r => r.CartoonId)
            .HasConstraintName("FK_Rating_Cartoon");  // Указываем имя внешнего ключа

    }
}


