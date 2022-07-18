using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            //_context.Products.Include(x => x.Category);
            _dbSet =  _context.Set<T>(); 
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet?.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includePropties = null)
        {

            IQueryable<T> query = _dbSet;
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(includePropties != null)
            {
                foreach (var item in includePropties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate, string? includePropties = null)
        {

            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            if (includePropties != null)
            {
                foreach (var item in includePropties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
