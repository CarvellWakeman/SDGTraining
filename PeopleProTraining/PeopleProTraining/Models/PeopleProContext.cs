using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PeopleProTraining.Models
{
    public class PeopleProContext : DbContext
    {
        // Members
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Building> Buildings { get; set; }

        // Remove Cascade Delete by default
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();
        }
    }
}