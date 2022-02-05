using BusinessLayer;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryEx.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IGenericRepository<Books> _repository;
        public BooksController(IGenericRepository<Books> repository) => _repository = repository;
        
        [Route("books")]
        [HttpGet]
        public IEnumerable<Books> GetBooks()
        {
            return _repository.GetAllPart();
        }

        [Route("book/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = _repository.Get(id);
            return book != null ? Ok(book) : NotFound(default);
        }

        [Route("book/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var t = _repository.GetAllPart().FirstOrDefault(x => x.BookId == id);
            if (t != null) { _repository.Delete(id); return Ok(); }
            else { return BadRequest(); }
        }

        [Route("books")]
        [HttpPost]
        public async Task<IActionResult> SetBooks(Books books)
        {
            if (_repository.GetAllPart().FirstOrDefault(x => x.BookName == books.BookName) == null)
            {
                _repository.Insert(books);
                return Ok();
            }
            else { return BadRequest(); }
        }

    }

}
