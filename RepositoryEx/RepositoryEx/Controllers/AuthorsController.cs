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
    public class AuthorsController : ControllerBase
    {
        private IGenericRepository<Authors> _repository;
        public AuthorsController(IGenericRepository<Authors> repository) => _repository = repository;

        [Route("authors")]
        [HttpGet]
        public IEnumerable<Authors> GetAuthors()
        {
            return _repository.GetAllPart();
        }

        [Route("author/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var Author = _repository.Get(id);
            return Author != null ? Ok(Author) : NotFound(default);
        }

        [Route("authors")]
        [HttpPost]
        public async Task<IActionResult> SetAuthor(Authors author)
        {
            if (_repository.GetAllPart().FirstOrDefault(x => x.AuthorName == author.AuthorName) == null)
            {
                _repository.Insert(author);
                return Ok();
            }
            else return BadRequest();
        }


        /*[Route("author/{id}")]
          [HttpDelete]

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var t = _repository.GetAllPart().FirstOrDefault(x => x.AuthorId == id);
            if (t != null)
            {
                _repository.Delete(id);
                return Ok();
            }
            else { return BadRequest(); }

        }*/


    }
}
