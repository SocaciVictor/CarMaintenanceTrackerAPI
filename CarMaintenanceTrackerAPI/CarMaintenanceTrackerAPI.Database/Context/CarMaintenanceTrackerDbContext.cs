using CarMaintenanceTracker.Database.Entities;
using CarMaintenanceTracker.Database.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenanceTracker.Database.Context
{
    public class CarMaintenanceTrackerDbContext : DbContext
    {
        public CarMaintenanceTrackerDbContext(DbContextOptions<CarMaintenanceTrackerDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<ServiceCenter> ServiceCenters { get; set; }
        public DbSet<CarServiceCenter> CarServiceCenters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurarea relației one-to-one între User și Car
            modelBuilder.Entity<User>()
                .HasOne(u => u.Car)
                .WithOne(c => c.User)
                .HasForeignKey<Car>(c => c.UserId);

            // Configurarea relației one-to-many între Car și MaintenanceRecord
            modelBuilder.Entity<Car>()
                .HasMany(c => c.MaintenanceRecords)
                .WithOne(mr => mr.Car)
                .HasForeignKey(mr => mr.CarId);

            // Configurarea relației many-to-many între Car și ServiceCenter
            modelBuilder.Entity<CarServiceCenter>()
                .HasKey(cs => new { cs.CarId, cs.ServiceCenterId });

            modelBuilder.Entity<CarServiceCenter>()
                .HasOne(cs => cs.Car)
                .WithMany(c => c.CarServiceCenters)
                .HasForeignKey(cs => cs.CarId);

            modelBuilder.Entity<CarServiceCenter>()
                .HasOne(cs => cs.ServiceCenter)
                .WithMany(sc => sc.CarServiceCenters)
                .HasForeignKey(cs => cs.ServiceCenterId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
              .UseSqlServer("Server=localhost;Database=dbCarMaintenanceTracker;User Id=sa2;Password=admin123;TrustServerCertificate=True")
              .LogTo(Console.WriteLine);
        }
    }
}
