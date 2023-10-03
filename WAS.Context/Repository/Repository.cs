using System;
using WAS.Model;
using WAS.Utility;
using WAS.Interface;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace WAS.Context
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationContext _context;
        private DbSet<T> _dbSet;
        public Repository(ApplicationContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
            this._context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public async Task Add(T entity) => await _dbSet.AddAsync(entity);
        public async Task AddRange(IEnumerable<T> entity) => await _dbSet.AddRangeAsync(entity);

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? inCludePropperties = null)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            query = query.Where(filter);

            if (!COM.IsNullOrEmpty(inCludePropperties))
            {
                foreach (string includeProp in inCludePropperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, string? includeProp = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!COM.IsNullOrEmpty(includeProp))
            {
                foreach (string prop in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllQueryable(Expression<Func<T, bool>> filter = null, string? includeProp = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!COM.IsNullOrEmpty(includeProp))
            {
                foreach (string prop in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return query;
        }

        public void Remove(T entity, string? includeProp = null)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities, string? includeProp = null) => _dbSet.RemoveRange(entities);

        //Process the data in the database
        //public IEnumerable<T> GetFilterData(string sortColumn, string sortColumnDir, string search, string propName)
        //{
        //    IQueryable<T> iquery = (from venue in _dbSet select venue);

        //    if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDir))
        //    {
        //        if (sortColumnDir.ToUpper() == "ASC")
        //        {
        //            iquery = iquery.OrderBy(val => val.GetType().GetProperty(sortColumn).GetValue(val));
        //        }
        //        else
        //        {
        //            iquery = iquery.OrderByDescending(val => val.GetType().GetProperty(sortColumn).GetValue(val));
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        iquery = iquery.Where(val => val.GetType().GetProperty(propName).GetValue(val).ToString().Contains(search));
        //    }

        //    return iquery;
        //}


        //Process the data in the locally
        public IEnumerable<T> GetFilterData(string sortColumn, string sortColumnDir, string search, string propName, string? includeprop = null)
        {
            IQueryable<T> iquery = (from equi in _dbSet select equi);

            if (!COM.IsNullOrEmpty(includeprop))
            {
                foreach (string prop in includeprop.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    iquery = iquery.Include(prop);
                }
            }

            var iEnum = iquery.ToList();

            if (iquery != null)
            {
                //Using reflection for getting equipment object propperty dynamically or using sorColname

                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDir))
                {
                    if (sortColumnDir.ToUpper() == "ASC")
                    {
                        iEnum = iEnum.AsEnumerable().OrderBy(dta => dta.GetType().GetProperty(sortColumn).GetValue(dta)).ToList();
                    }
                    else
                    {
                        iEnum = iEnum.AsEnumerable().OrderBy(dta => dta.GetType().GetProperty(sortColumn).GetValue(dta)).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(search))
                {
                    iEnum = iEnum.Where(dta => dta.GetType().GetProperty(propName).GetValue(dta).ToString().ToLower().Contains(search.ToLower())).ToList();
                }
            }

            return iEnum.ToList();
        }
        public async Task<int> GetCount()
        {
            return await _dbSet.CountAsync();
        }
    }
}
