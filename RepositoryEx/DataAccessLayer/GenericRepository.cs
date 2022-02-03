using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) => _context = context;

        public int Delete(int id)
        {
            _context.Remove<TEntity>(Get(id));
            return _context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(string include, string include2)
        {
            return _context.Set<TEntity>().Include(include).Include(include2);
        }

        public int Insert(TEntity entity)
        {
            _context.Add<TEntity>(entity);
            return _context.SaveChanges();
        }

    }
}
