using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApi.Domain.Entities;

namespace BooksApi.Domain.Interfaces
{
    public interface IBaseRepository<Book> where Book : BaseBook
    {
        //Task<IEnumerable<Book>> Get();
        //Task<Book> Get(int Id);
        //Task<Book> Create(Book book);
        //Task Update(Book book);
        //Task Delete(int Id);

        void Insert(Book book);
        void Update(Book book);
        void Delete(int Id);
        IList<Book> Select();
        Book Select(int Id);
    }
}
