﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Template.DataAccess.Core;




namespace Template.DataAccess.Core
{
    public class RepositoryMessageQueue : IRepositoryBase
    {

        public RepositoryMessageQueue()
        {

        }

        public void Delete<T>(object Id) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(object Id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Insert<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }

        public void Save<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }


        /*
        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return All<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T : class
        {
            throw new NotImplementedException();
            //return _context.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
            //return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            throw new NotImplementedException();

            //int skipCount = index * size;
            //var _resetSet = filter != null ? _context.Set<T>().Where<T>(filter).AsQueryable() : _context.Set<T>().AsQueryable();
            //_resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            //total = _resetSet.Count();
            //return _resetSet.AsQueryable();
        }

        public virtual void Create<T>(T TObject) where T : class
        {
            throw new NotImplementedException();

            // var newEntry = _context.Set<T>().Add(TObject); 
        }

        public virtual void Delete<T>(T TObject) where T : class
        {
            throw new NotImplementedException();
            // _context.Set<T>().Remove(TObject);
        }

        public virtual void Update<T>(T TObject) where T : class
        {
            throw new NotImplementedException();

            //try
            //{
            //    var entry = _context.Entry(TObject);
            //    _context.Set<T>().Attach(TObject);
            //    entry.State = EntityState.Modified;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();

            // var objects = Filter<T>(predicate);
            // foreach (var obj in objects)
            //     _context.Set<T>().Remove(obj);
        }
        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
            // return _context.Set<T>().Count<T>(predicate) > 0;
        }
        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
            // return _context.Set<T>().FirstOrDefault<T>(predicate);
        }
        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            throw new NotImplementedException();
            // _context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }
        */
    }
}
