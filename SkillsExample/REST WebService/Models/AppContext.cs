using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace REST_WebService.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drawer>().HasData(
                new Drawer
                {
                    Id = 1,
                    Width = 30,
                    Height = 10,
                    Length = 15,
                },
                new Drawer
                {
                    Id = 2,
                    Width = 30,
                    Height = 10,
                    Length = 15,
                },
                new Drawer
                {
                    Id = 3,
                    Width = 30,
                    Height = 10,
                    Length = 15
                },
                new Drawer
                {
                    Id = 4,
                    Width = 15,
                    Height = 15,
                    Length = 15
                },
                new Drawer
                {
                    Id = 5,
                    Width = 10,
                    Height = 40,
                    Length = 15
                }
            );
            modelBuilder.Entity<Storage>().HasData(
                new Storage
                {
                    Id = 1,
                    Name = "Storage in Livingroom",
                    Width = 60,
                    Height = 15,
                    Length = 15,      
                },
                new Storage
                {
                    Id = 2,
                    Name = "hidden storage",
                    Width = 35,
                    Height = 60,
                    Length = 35
                },
                new Storage
                {
                    Id = 3,
                    Name = "Weapon storage",
                    Width = 220,
                    Height = 120,
                    Length = 50
                }
            );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Arduino UNO",
                    Width = 6.9d,
                    Height = 5.3d,
                    Length = 1.2d,
                    Weight = 0.025d,
                    Description = " an open-source microcontroller board based on the Microchip ATmega328P microcontroller and developed by Arduino.cc.",
                    LinkToSite = "https://www.arduino.cc/",
                    UnitCost = 16.00M

                });
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Value = "Arduino",
                },
                new Tag
                {
                    Id = 2,
                    Value = "Board",
                },
                new Tag
                {
                    Id = 3,
                    Value = "5V",
                },
                new Tag
                {
                    Id = 4,
                    Value = "3.3V",
                },
                new Tag
                {
                    Id = 5,
                    Value = "Beginners",
                }
            );
        }
    }
}
