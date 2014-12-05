using System.Data.Entity;

namespace TxBomkarlWorkerRole
{
    public class TxBomkarlDbContext : DbContext
    {

        public TxBomkarlDbContext(): base("dont need a connectionstring or database to reproduce")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Thing>().ToTable("Thing").HasKey(t => new { t.Id });
        }

        public DbSet<Thing> Things { get; set; }
    }
}