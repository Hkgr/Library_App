using Library_Domin;
using Microsoft.EntityFrameworkCore;

namespace Library_Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = Library_DB1");
        }
    }
}