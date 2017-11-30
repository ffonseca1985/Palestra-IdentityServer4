using ISMeetup.Infraestructure.MySqlEntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ISMeetup.Infraestructure.MySqlEntityFramework.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        private UserContext _context;

        public RepositoryBase(UserContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return this._context.Set<T>().ToList();
        }

        public T Find(params object[] ids)
        {
            return _context.Set<T>().Find(ids);
        }

        public IEnumerable<T> Get(int currentPage, int totalByPage)
        {
            return _context.Set<T>().Skip(currentPage - 1).Take(totalByPage).ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
