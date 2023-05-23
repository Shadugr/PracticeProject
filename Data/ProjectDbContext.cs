using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        //public ProjectDbContext() => Database.EnsureCreated();
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
                .HasForeignKey<Land>(l => l.advert_id);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Advert)
                .WithMany(a => a.Photos)
                .HasForeignKey(p => p.advert_id);

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
                    name = "test",
                    surname = "user1",
                    PhoneNumber = "380123456789",
                    Email = "user1@gmail.com",
                    is_active = true,
                    created_at = DateTime.Now
                };
                User user2 =
                new User
                {
                    name = "test",
                    surname = "user2",
                    PhoneNumber = "380987654321",
                    Email = "user2@gmail.com",
                    is_active = true,
                    created_at = DateTime.Now
                };
                db.Users.AddRange(user1, user2);

                Flat flat1 = new Flat
                {
                    floor = 1,
                    storey = 1,
                    square = 50,
                    building_age = 5
                };
                Flat flat2 = new Flat
                {
                    floor = 2,
                    storey = 2,
                    square = 30,
                    building_age = 5
                };
                db.Flats.AddRange(flat1, flat2);

                Land land1 = new Land
                {
                    type_of_land = "type1",
                    area = 100,
                    area_dimension = 100
                };
                db.Lands.AddRange(land1);

                Advert advert1 = new Advert
                {
                    path_to_property = "path1",
                    title = "title1",
                    location = "location1",
                    description = "description1",
                    price = 100000,
                    view_number = 1,
                    is_active = true,
                    created_at = DateTime.Now,

                    User = user1,
                    Flat = flat1
                };
                Advert advert2 = new Advert
                {
                    path_to_property = "path2",
                    title = "title2",
                    location = "location2",
                    description = "description2",
                    price = 200000,
                    view_number = 1,
                    is_active = true,
                    created_at = DateTime.Now,

                    User = user1,
                    Flat = flat2
                };
                Advert advert3 = new Advert
                {
                    path_to_property = "path3",
                    title = "title3",
                    location = "location3",
                    description = "description3",
                    price = 300000,
                    view_number = 1,
                    is_active = true,
                    created_at = DateTime.Now,

                    User = user2,
                    Land = land1
                };
                db.Adverts.AddRange(advert1, advert2, advert3);


                Photo photo1 = new Photo { path_to_file = "path1", Advert = advert1 };
                Photo photo2 = new Photo { path_to_file = "path1", Advert = advert2 };
                Photo photo3 = new Photo { path_to_file = "path1", Advert = advert3 };
                db.Photos.AddRange(photo1, photo2, photo3);

                db.SaveChanges();
                
            }
        }*/
    }
}
