using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WAS.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, string? includeProp = null);
        Task<IQueryable<T>> GetAllQueryable(Expression<Func<T, bool>> filter = null, string? includeProp = null);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp = null);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entity);
        void Remove(T entity, string? includeprop = null);
        void RemoveRange(IEnumerable<T> entities, string? includProp = null);
        IEnumerable<T> GetFilterData(string sortColumn, string sortColumnDir, string search, string propName, string? includeProp = null);
        public Task<int> GetCount();
    }
}
