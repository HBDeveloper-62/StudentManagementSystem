using Microsoft.EntityFrameworkCore;
using SMS.Models;
using System.Security.Claims;

namespace SMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets for your models  
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<FeeRecord> FeeRecords { get; set; }
        public DbSet<Admission> Admissions { get; set; }

        // Fix for CS0246: Ensure the 'Class' type is properly referenced  
      
        public DbSet<EventExam> EventExams { get; set; }
        public DbSet<SystemNotification> SystemNotifications { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<BackupLog> BackupLogs { get; set; }


        // Optional: Fluent API configs can be added here  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add your configuration here:
            modelBuilder.Entity<FeeRecord>(entity =>
            {
                entity.Property(e => e.Amount)
                      .HasColumnType("decimal(18,2)");  // specify precision and scale explicitly
            });
        }
    }
}
