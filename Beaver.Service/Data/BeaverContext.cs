using System.Data.Entity;
using Beaver.Service.Data.Entities;

namespace Beaver.Service.Data
{
    internal class BeaverContext : DbContext
    {
        public BeaverContext()
            : base("name=BeaverContext")
        {
            Database.SetInitializer(new BeaverContextInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(BeaverContext context)
        {
           
        }
    }
}
