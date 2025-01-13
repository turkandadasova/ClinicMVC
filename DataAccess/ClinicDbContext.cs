using ClinicMVC.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace ClinicMVC.DataAccess
{
    public class ClinicDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(t => t.Doctors)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId);
        }

        public ClinicDbContext(DbContextOptions opt) : base(opt) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
