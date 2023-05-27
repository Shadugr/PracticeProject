using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PracticeProject.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;

namespace PracticeProject.Data
{
    
    public class ProjectDbContext : IdentityDbContext<User>
    {
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public ProjectDbContext(DbContextOptions options) : base(options) { } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Advert>()
                .HasOne(a => a.User)
                .WithMany(u => u.Adverts)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Flat>()
                .HasOne(f => f.Advert)
                .WithOne(a => a.Flat)
                .HasForeignKey<Flat>(f => f.AdvertId);

            modelBuilder.Entity<Land>()
                .HasOne(l => l.Advert)
                .WithOne(a => a.Land)
                .HasForeignKey<Land>(l => l.AdvertId);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Advert)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.AdvertId);
        }
    }
}
