using System.Data.Entity;

namespace AmendoTest.Models
{
    public class AmendoBookDBContext : DbContext
    {
        public AmendoBookDBContext() : base("BookDB")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {        
            base.OnModelCreating(modelBuilder);
        }
    }
}