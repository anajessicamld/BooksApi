using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApi.Domain.Entities;
using BooksApi.Domain.Interfaces;
using BooksApi.Infra.Data.Context;


namespace BooksApi.Infra.Data.Repository
{
    public class BaseRepository<Book> : IBaseRepository<Book> where Book : BaseBook
    {
        protected readonly BookContext _SqlServerContext;

        public BaseRepository(BookContext SqlServerContext)
        {
            _SqlServerContext = SqlServerContext;
        }

        public void Insert(Book book)
        {
            _SqlServerContext.Set<Book>().Add(book);
             _SqlServerContext.SaveChanges();
        }

        public void Update(Book book)
        {
            _SqlServerContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _SqlServerContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _SqlServerContext.Set<Book>().Remove(Select(Id));
            _SqlServerContext.SaveChanges();
        }

        public IList<Book> Select() =>
            _SqlServerContext.Set<Book>().ToList();

        public Book Select(int Id) =>
            _SqlServerContext.Set<Book>().Find(Id);
    }
}
