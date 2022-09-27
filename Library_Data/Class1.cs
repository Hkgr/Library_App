using Library_Domin;
using Microsoft.EntityFrameworkCore;

namespace Library_Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<uspwd> uspwds { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Library_DB");
        }
    }
}