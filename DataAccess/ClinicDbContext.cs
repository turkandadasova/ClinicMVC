using ClinicMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.DataAccess
{
    public class ClinicDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ClinicDbContext(DbContextOptions opt) : base(opt) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
