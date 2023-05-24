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
        public ProjectDbContext() { }
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




            User user1 = new User { Id = "1", Name = "test", Surname = "user1", PhoneNumber = "380123456789", Email = "user1@gmail.com", IsActive = true, CreatedAt = DateTime.Now };
            User user2 = new User { Id = "2", Name = "test", Surname = "user2", PhoneNumber = "380987654321", Email = "user2@gmail.com", IsActive = true, CreatedAt = DateTime.Now };
            Advert advert1 = new Advert { Id = 1, UserId = user1.Id, PathToProperty = "path1", Title = "title1", Location = "location1", Description = "description1", Price = 100000, ViewNumber = 1, IsActive = true, CreatedAt = DateTime.Now };
            Advert advert2 = new Advert { Id = 2, UserId = user1.Id, PathToProperty = "path2", Title = "title2", Location = "location2", Description = "description2", Price = 200000, ViewNumber = 1, IsActive = true, CreatedAt = DateTime.Now };
            Advert advert3 = new Advert { Id = 3, UserId = user2.Id, PathToProperty = "path3", Title = "title3", Location = "location3", Description = "description3", Price = 300000, ViewNumber = 1, IsActive = true, CreatedAt = DateTime.Now };
            Flat flat1 = new Flat { Id = 1, AdvertId = advert1.Id, Floor = 1, Storey = 5, Square = 50, BuildingAge = 5 };
            Flat flat2 = new Flat { Id = 2, AdvertId = advert2.Id, Floor = 2, Storey = 5, Square = 30, BuildingAge = 5 };
            Land land1 = new Land { Id = 1, AdvertId = advert3.Id, TypeOfLand = "type1", Area = 100, AreaDimension = 100 };
            Photo photo1 = new Photo { Id = 1, AdvertId = advert1.Id, PathToFile = "path1" };
            Photo photo2 = new Photo { Id = 2, AdvertId = advert2.Id, PathToFile = "path1" };
            Photo photo3 = new Photo { Id = 3, AdvertId = advert3.Id, PathToFile = "path1" };


            modelBuilder.Entity<User>().HasData(new[] { user1, user2 });
            modelBuilder.Entity<Flat>().HasData(new[] { flat1, flat2 });
            modelBuilder.Entity<Land>().HasData(new[] { land1 });
            modelBuilder.Entity<Advert>().HasData(new[] { advert1, advert2, advert3 });
            modelBuilder.Entity<Photo>().HasData(new[] { photo1, photo2, photo3 });

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=TestDB;Trusted_Connection=True;Encrypt=false;";
            optionsBuilder.UseSqlServer(connectionString);
        }*/

        /*public void Identity()
        {
            using (ProjectDbContext db = new ProjectDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                User user1 = new User
                {
                    Name = "test",
                    Surname = "user1",
                    PhoneNumber = "380123456789",
                    Email = "user1@gmail.com",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };
                User user2 =
                new User
                {
                    Name = "test",
                    Surname = "user2",
                    PhoneNumber = "380987654321",
                    Email = "user2@gmail.com",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };
                db.Users.AddRange(user1, user2);

                Flat flat1 = new Flat
                {
                    Floor = 1,
                    Storey = 1,
                    Square = 50,
                    BuildingAge = 5
                };
                Flat flat2 = new Flat
                {
                    Floor = 2,
                    Storey = 2,
                    Square = 30,
                    BuildingAge = 5
                };
                db.Flats.AddRange(flat1, flat2);

                Land land1 = new Land
                {
                    TypeOfLand = "type1",
                    Area = 100,
                    AreaDimension = 100
                };
                db.Lands.AddRange(land1);

                Advert advert1 = new Advert
                {
                    PathToProperty = "path1",
                    Title = "title1",
                    Location = "location1",
                    Description = "description1",
                    Price = 100000,
                    ViewNumber = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,

                    User = user1,
                    Flat = flat1
                };
                Advert advert2 = new Advert
                {
                    PathToProperty = "path2",
                    Title = "title2",
                    Location = "location2",
                    Description = "description2",
                    Price = 200000,
                    ViewNumber = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,

                    User = user1,
                    Flat = flat2
                };
                Advert advert3 = new Advert
                {
                    PathToProperty = "path3",
                    Title = "title3",
                    Location = "location3",
                    Description = "description3",
                    Price = 300000,
                    ViewNumber = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,

                    User = user2,
                    Land = land1
                };
                db.Adverts.AddRange(advert1, advert2, advert3);


                Photo photo1 = new Photo { PathToFile = "path1", Advert = advert1 };
                Photo photo2 = new Photo { PathToFile = "path1", Advert = advert2 };
                Photo photo3 = new Photo { PathToFile = "path1", Advert = advert3 };
                db.Photos.AddRange(photo1, photo2, photo3);

                db.SaveChanges();

            }
        }*/
    }
}
