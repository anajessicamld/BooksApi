using BooksApi.Model;
using BooksApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")] //rotas (onde vai buscar)
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;//chamando a interface apenas para leitura
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet] //endpoint
        public async Task<IEnumerable<Book>> GetBooks() //chamar o async para a chamada também ser assíncrona assim como o método
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")] //endpoint com parâmetro, pois busca pelo id
        public async Task<ActionResult<Book>> GetBooks(int id) //não tem problema ter endpoints com o mesmo nome, se tiverem parâmetros distintos
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost] 
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book) 
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = newBook.Id}, newBook);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.Delete(bookToDelete.Id); //else
            return NoContent();

            
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks (int id,[FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest();

                await _bookRepository.Update(book);

            return NoContent();
        }

    }
}
