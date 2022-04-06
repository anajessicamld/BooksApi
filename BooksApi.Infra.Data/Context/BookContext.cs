using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApi.Domain.Entities;
using BooksApi.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infra.Data.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
           // Database.EnsureCreated(); //cria o banco (a menos que já exista)
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(new BookMap().Configure);
        }
    }
}
