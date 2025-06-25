using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeJobs
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Employee> Employees { get; } = new();
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? JobId { get; set; }  // nullable FK
        public Job Job { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost;Database=EmployeeJobs;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId)
            // Try one of these:
            //.OnDelete(DeleteBehavior.ClientSetNull);
            //.OnDelete(DeleteBehavior.NoAction);
            .OnDelete(DeleteBehavior.SetNull);
            //.OnDelete(DeleteBehavior.Cascade);
            //.OnDelete(DeleteBehavior.Restrict);  // pick one
        }
    }

}
