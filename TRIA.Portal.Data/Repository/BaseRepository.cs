using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TRIA.Portal.Domain.Interfaces.Repository;

namespace TRIA.Portal.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> Alterar(T obj)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    _context.Entry(obj).State = EntityState.Modified;
                    return 1;
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual async Task<T> ConsultarPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> ConsultarTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<int> Excluir(T obj)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    _context.Set<T>().Remove(obj);

                    return 1;

                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual async Task<int> Inserir(T obj)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    _context.Set<T>().Add(obj);

                    return 1;
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual async Task<int> InserirList(IEnumerable<T> obj)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    _context.AddRange(obj);
                    return 1;
                });
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public virtual async Task<List<T>> ConsultaPersonalizada(Expression<Func<T, bool>> where) => await _context.Set<T>().Where(where).ToListAsync();

        public virtual async Task<IList<T>> ConsultaPersonalizada(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            var queryable = _context.Set<T>() as IQueryable<T>;

            return await (includes.Aggregate(queryable.Where(where), (query, path) => query.Include(path))).ToListAsync();
        }

        public virtual async Task<IList<T>> ConsultaPersonalizada(Expression<Func<T, bool>> where, Expression<Func<T, int>> orderBy, params Expression<Func<T, object>>[] includes)
        {
            var queryable = _context.Set<T>() as IQueryable<T>;

            return await (includes.Aggregate(queryable.Where(where).OrderBy(orderBy).AsQueryable(), (query, path) => query.Include(path))).ToListAsync();
        }

        public virtual async Task<T> ConsultarPorId(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return await Task.Factory.StartNew(() => { return includes.Aggregate(_context.Set<T>().Where(where), (query, path) => query.Include(path)).FirstOrDefault(); });
            }
            catch (Exception ex) { throw ex; }
        }

        public virtual async Task Detach(Func<T, bool> predicate)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    var local = _context.Set<T>().Local.Where(predicate).FirstOrDefault();
                    if (local != null)
                    {
                        _context.Entry(local).State = EntityState.Detached;
                    }
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual async Task<T> ConsultarPorIdAsNoTraking(Expression<Func<T, bool>> where)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(where);
        }
    }
}
