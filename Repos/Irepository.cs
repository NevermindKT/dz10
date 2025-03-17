using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T? GetId(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
