using Microsoft.EntityFrameworkCore;
using Practical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>().HasData(new Department[] {
                 new Department{ Name = "Accounting", AnnualBudget = 1000, DepartmentId='m' },
                 new Department{ Name = "Engineering", AnnualBudget = 1200, DepartmentId='n' }
             });

            builder.Entity<Club>().HasData(new Club[] {
                 new Club{ ClubId='A', Name="Roadtrip" },
                 new Club{ ClubId='B', Name="Boating" }
             });

            builder.Entity<Employee>().HasData(new Employee[] {
                 new Employee{ EmploeeId = 1, Name= "Satish", ClubId='A', DepartmentId = 'm' },
                 new Employee{ EmploeeId = 2, Name= "Hiren", ClubId='B', DepartmentId = 'm' },
                 new Employee{ EmploeeId = 3, Name= "Naren", ClubId='A', DepartmentId = 'n' },
                 new Employee{ EmploeeId = 4, Name= "Chris", ClubId='A', DepartmentId = 'm' },
                 new Employee{ EmploeeId = 5, Name= "Jon", ClubId='B', DepartmentId = 'n' }
             });

            builder.Entity<Employee>().HasOne(b => b.Department).WithMany(a => a.employees).OnDelete(DeleteBehavior.SetNull);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
