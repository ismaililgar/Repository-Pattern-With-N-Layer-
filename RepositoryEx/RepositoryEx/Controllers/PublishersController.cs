using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RepositoryEx.Controllers
{
    [Route("api")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private IGenericRepository<Publishers> _repository;
        public PublishersController(IGenericRepository<Publishers> repository) => _repository = repository;

        [Route("publishers")]
        [HttpGet]
        public IEnumerable<Publishers> GetPublishers()
        {
            return _repository.GetAllPart();
        }

        [Route("publisher/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPublisher(int id)
        {
            var Publish = _repository.Get(id);
            return Publish != null ? Ok(Publish) : NotFound(default);
        }

        [Route("publishers")]
        [HttpPost]
        public async Task<IActionResult> SetPublisher(Publishers publisher)
        {
            if (_repository.GetAllPart().FirstOrDefault(x => x.PublisherName == publisher.PublisherName) == null)
            {
                _repository.Insert(publisher);
                return Ok();
            }
            else { return BadRequest(); }
        }
    }
}
