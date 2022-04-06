using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooksApi.Domain.Entities;
using BooksApi.Domain.Interfaces;
using BooksApi.Service.Validators;
using System;

namespace BooksApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseService<Book> _baseUserService;

        public BookController(IBaseService<Book> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<BookValidator>(book).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            if (book == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<BookValidator>(book));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(Id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            if (Id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById(Id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
