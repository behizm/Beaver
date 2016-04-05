using System.Data.Entity;
using Beaver.Service.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Beaver.Service.Data
{
    public class BeaverContext : IdentityDbContext<ApplicationUser>
    {
        public BeaverContext()
            : base("name=BeaverContext")
        {
            Database.SetInitializer(new BeaverContextInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentInf> ApartmentInfs { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Unit> Units { get; set; }

        public static BeaverContext Create()
        {
            return new BeaverContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Seed(BeaverContext context)
        {
           
        }
    }
}
