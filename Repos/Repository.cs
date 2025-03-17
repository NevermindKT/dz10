using Microsoft.EntityFrameworkCore;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T? GetId(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}