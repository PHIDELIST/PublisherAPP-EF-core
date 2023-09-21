using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLOCALDB; Initial Catalog = PubDatabase"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Rhoda", LastName = "Okeyo" });
            var authorList = new Author[]
            {
                new Author { Id = 2, FirstName = "Rhoda", LastName = "Okeyo" },
                new Author { Id = 3, FirstName = "Rhoda", LastName = "Okeyo" },
                new Author { Id = 4, FirstName = "Rhoda", LastName = "Okeyo" },
                new Author { Id = 5, FirstName = "Rhoda", LastName = "Okeyo" },
                new Author { Id = 6, FirstName = "Rhoda", LastName = "Okeyo" },
                new Author { Id = 7, FirstName = "Rhoda", LastName = "Okeyo" },
                new Author { Id = 8, FirstName = "Rhoda", LastName = "Okeyo" }
            };
            modelBuilder.Entity<Author>().HasData(authorList );

        }
    }
}