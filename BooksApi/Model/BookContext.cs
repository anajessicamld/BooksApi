using Microsoft.EntityFrameworkCore;

namespace BooksApi.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated(); //cria o banco (a menos que já exista)
        }

        public DbSet<Book> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Password=A1234sdf;Persist Security Info=True;User ID=sa;Initial Catalog=books;Data Source=.");
        //}
    }
}
