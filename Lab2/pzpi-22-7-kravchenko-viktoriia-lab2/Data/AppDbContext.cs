using System.Collections.Generic;
using System.Data.Entity;
using AquaTrack.Data.Models;

namespace AquaTrack.Data
{
    public class AppDbContext : DbContext
    {
        // Конструктор з підключенням до бази даних
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        // Таблиці
        public DbSet<User> Users { get; set; }
        public DbSet<IoTDevice> IoTDevices { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<WaterUsage> WaterUsages { get; set; }

        // Конфігурація зіставлення моделей із таблицями
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Налаштування для таблиці Users
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasColumnName("username");
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasColumnName("email");
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasColumnName("password_hash");
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasColumnName("role");

            // Налаштування для таблиці Limits
            modelBuilder.Entity<Limit>().ToTable("Limits");
            modelBuilder.Entity<Limit>()
                .Property(l => l.LimitId)
                .HasColumnName("limit_id");
            modelBuilder.Entity<Limit>()
                .Property(l => l.LimitValue)
                .HasColumnName("limit_value");
            modelBuilder.Entity<Limit>()
                .Property(l => l.StartDate)
                .HasColumnName("start_date");
            modelBuilder.Entity<Limit>()
                .Property(l => l.EndDate)
                .HasColumnName("end_date");
            modelBuilder.Entity<Limit>()
                .Property(l => l.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<Limit>()
                .Property(l => l.DeviceId)
                .HasColumnName("device_id");

            // Налаштування для таблиці IoTDevice
            modelBuilder.Entity<IoTDevice>().ToTable("IoTDevice");
            modelBuilder.Entity<IoTDevice>()
                .Property(d => d.DeviceId)
                .HasColumnName("device_id");
            modelBuilder.Entity<IoTDevice>()
                .Property(d => d.DeviceType)
                .HasColumnName("device_type");
            modelBuilder.Entity<IoTDevice>()
                .Property(d => d.Status)
                .HasColumnName("status");

            // Налаштування для таблиці WaterUsage
            modelBuilder.Entity<WaterUsage>().ToTable("WaterUsage");
            modelBuilder.Entity<WaterUsage>()
                .Property(w => w.UsageId)
                .HasColumnName("usage_id");
            modelBuilder.Entity<WaterUsage>()
                .Property(w => w.DeviceId)
                .HasColumnName("device_id");
            modelBuilder.Entity<WaterUsage>()
                .Property(w => w.UsageValue)
                .HasColumnName("usage_value");
            modelBuilder.Entity<WaterUsage>()
                .Property(w => w.Timestamp)
                .HasColumnName("timestamp");

            base.OnModelCreating(modelBuilder);
        }
    }
}

