namespace CrunchSharp
{
    using CrunchBase;
    using CrunchSharp.Data;
    using System.Data.Entity;

    public class MainContext : DbContext
    {
        public MainContext(string nameOrConnectionString = null) : base(nameOrConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Acquisition> Acquisitions { get; set; }

        public DbSet<Ipo> Ipo { get; set; }

        public DbSet<FundingRound> FundingRounds { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ipo>()
                .HasRequired(i => i.Organization)
                .WithOptional(s => s.Ipo);
        }
    }
}
