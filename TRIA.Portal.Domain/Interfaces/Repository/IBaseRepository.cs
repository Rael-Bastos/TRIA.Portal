using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TRIA.Portal.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> Alterar(T obj);
        Task<T> ConsultarPorId(int id);
        Task<List<T>> ConsultarTodos();
        Task<int> Excluir(T obj);
        Task<int> Inserir(T obj);
        Task<int> InserirList(IEnumerable<T> obj);
        Task<List<T>> ConsultaPersonalizada(Expression<Func<T, bool>> where);
        Task<IList<T>> ConsultaPersonalizada(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> ConsultaPersonalizada(Expression<Func<T, bool>> where, Expression<Func<T, int>> orderBy, params Expression<Func<T, object>>[] includes);
        Task<T> ConsultarPorId(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task Detach(Func<T, bool> predicate);
        Task<T> ConsultarPorIdAsNoTraking(Expression<Func<T, bool>> where);
    }
}
