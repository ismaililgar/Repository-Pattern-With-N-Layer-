using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(string a1, string a2);
        IEnumerable<TEntity> GetAllPart();
        int Delete(int id);
       int Insert(TEntity entity);
    }
}
