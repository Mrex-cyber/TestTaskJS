using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace TestTaskJS.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UsersList");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.UserEvents)
                .WithOne(e => e.UserOfEvent)
                .OnDelete(DeleteBehavior.Cascade);


            User tom = new User
            {
                Id = 1,
                UserName = "Tom",
                Email = "agawegwa@gmail.com",
                PhoneNumber = "1234567890",
                NextEventDate = "15"
            };
            User bob = new User
            {
                Id = 2,
                UserName = "Bob",
                Email = "bobov@gmail.com",
                PhoneNumber = "3532472575346",
                NextEventDate = "20"
            };
            List<Event> events= new List<Event>()
            {
                new Event()
                {
                    Id = 1,
                    Title = "Test",
                    Description = "It is testing event",
                    StartDate = "15.02.2023",
                    EndDate = "27.02.2023",
                    UserOfEventId = tom.Id
                },
                new Event()
                {
                    Id = 2,
                    Title = "Test",
                    Description = "It is testing event",
                    StartDate = "15.02.2023",
                    EndDate = "27.02.2023",
                    UserOfEventId = tom.Id
                },
                new Event()
                {
                    Id = 3,
                    Title = "Test",
                    Description = "It is testing event",
                    StartDate = "15.02.2023",
                    EndDate = "27.02.2023",
                    UserOfEventId = bob.Id
                },
                new Event()
                {
                    Id = 4,
                    Title = "Test",
                    Description = "It is testing event",
                    StartDate = "15.02.2023",
                    EndDate = "27.02.2023",
                    UserOfEventId = bob.Id
                }
            };

            builder.Entity<User>().HasData(tom, bob);
            builder.Entity<Event>().HasData(events);
        }
    }
}
