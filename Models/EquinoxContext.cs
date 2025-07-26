using Microsoft.EntityFrameworkCore;

namespace Equinox.Models
{
    public class EquinoxContext : DbContext
    {
        public EquinoxContext(DbContextOptions<EquinoxContext> options)
            : base(options) { }

        public DbSet<EquinoxClass> Classes => Set<EquinoxClass>();
        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<ClassCategory> ClassCategories => Set<ClassCategory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Clubs
            modelBuilder.Entity<Club>().HasData(
                new Club { ClubId = 1, Name = "Chicago Loop", PhoneNumber = "812-234-4563" },
                new Club { ClubId = 2, Name = "Lincoln Park", PhoneNumber = "630-567-4561" },
                 new Club { ClubId = 3, Name = "Wheaton Park", PhoneNumber = "456-567-4561" }
            );

            // Seed ClassCategories
            modelBuilder.Entity<ClassCategory>().HasData(
                new ClassCategory { ClassCategoryId = 1, Name = "Yoga" },
                new ClassCategory { ClassCategoryId = 2, Name = "HIIT" },
                new ClassCategory { ClassCategoryId = 3, Name = "Boxing" }
            );

            // Seed Users (Coaches)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Peter John",
                    PhoneNumber = "456-678-2345",
                    Email = "john@example.com",
                    DOB = new DateTime(2000, 2, 10),
                    IsCoach = true
                },
                new User
                {
                    UserId = 2,
                    Name = "Peter Parker",
                    PhoneNumber = "675-678-2345",
                    Email = "parker@example.com",
                    DOB = new DateTime(1978, 3, 20),
                    IsCoach = true
                },
                 new User
                {
                    UserId = 3,
                    Name = "Scot Adam",
                    PhoneNumber = "675-123-2345",
                    Email = "adam@example.com",
                    DOB = new DateTime(1988, 3, 20),
                    IsCoach = true
                }
            );

            // Seed Equinox Classes
            modelBuilder.Entity<EquinoxClass>().HasData(
                new EquinoxClass
                {
                    EquinoxClassId = 1,
                    Name = "Hatha Yoga",
                    ClassPicture = "hatha.jpg",
                    ClassDay = "Saturday",
                    Time = "8 AM – 9 AM",
                    ClassCategoryId = 1,
                    UserId = 1,
                    ClubId = 1
                },
                new EquinoxClass
                {
                    EquinoxClassId = 2,
                    Name = "HIIT Junior",
                    ClassPicture = "hiit.jpg",
                    ClassDay = "Friday",
                    Time = "6 PM – 7 PM",
                    ClassCategoryId = 2,
                    UserId = 2,
                    ClubId = 2
                },
                 new EquinoxClass
                {
                    EquinoxClassId = 3,
                    Name = "HIIT Senior",
                    ClassPicture = "hiit2.jpg",
                    ClassDay = "Monday",
                    Time = "6 PM – 7 PM",
                    ClassCategoryId = 2,
                    UserId = 3,
                    ClubId = 3
                }
            );
        }
    }
}
