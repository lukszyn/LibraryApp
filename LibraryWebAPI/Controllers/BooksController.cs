using LibraryWebAPI.Models;
using LibraryWebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryWebAPI.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService BooksService)
        {
            _booksService = BooksService;
        }

        [HttpPost]
        public int PostBook([FromBody] Book book)
        {
            var bookId = _booksService.Add(book);
            return bookId;
        }

        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return _booksService.Get(id);
        }

        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return _booksService.GetAll();
        }

        [HttpPut("{id}")]
        public int PutBook(int id, [FromBody] Book book)
        {
            return _booksService.Update(id, book);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _booksService.Delete(id);
        }
    }
}
