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
        }

        public DbSet<Thing> Things { get; set; }
    }
}