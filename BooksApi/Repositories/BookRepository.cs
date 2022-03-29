using BooksApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context; //readonly - só leitura (não pode implementar a classe)
        public BookRepository(BookContext context) 
        {
            _context = context;
        }
        public async Task<Book> Create(Book book) //async - salvar os dados de forma assincrona
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync(); //await - espere até processar o que está em fila e executa isso como prox
            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id); //busca pelo id antes de deletar e atribui a var
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync(); //await, pois é uma ação para salvar a alteração
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id); //busca pelo id (assim como no Delete)
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified; //entidade que existe no database vai ser modificada
            await _context.SaveChangesAsync();
        }
    }
}
