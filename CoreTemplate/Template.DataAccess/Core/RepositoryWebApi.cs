using Microsoft.EntityFrameworkCore;
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



// ref: https://stackoverflow.com/questions/38379360/examples-of-repository-pattern-with-consuming-an-external-rest-web-service-via-h

namespace Template.DataAccess.Core
{
    public class RepositoryWebApi : IRepository
    {
        private static string baseUrl = "https://example.com/api/";

        public RepositoryWebApi()
        {

        }


        // These are specific and not in the the interface. but we could make another interface? maybe not.
        //public async Task<User> GetUserAsync(int userId)
        //{
        //    var userJson = await GetStringAsync(baseUrl + "users/" + userId);
        //    // Here I use Newtonsoft.Json to deserialize JSON string to User object
        //    var user = JsonConvert.DeserializeObject<User>(userJson);
        //    return user;
        //}

        //private static async Task<string> GetStringAsync(string url)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        return await httpClient.GetStringAsync(url);
        //    }
        //}



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
            //var objects = Filter<T>(predicate);
            //foreach (var obj in objects)
            //    _context.Set<T>().Remove(obj);
        }
        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
            //return _context.Set<T>().Count<T>(predicate) > 0;
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

    }
}
