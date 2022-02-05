using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BooksManager
    {
        private IGenericRepository<Books> _repository;
        public BooksManager(IGenericRepository<Books> repository) => _repository = repository;
       /* public IEnumerable<Books> GetBooks()
        {
            return _repository.GetAll("Authors", "Publisher");
        } */



    }
}
