﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Template.Common.BusinessObjects;
using Template.Common.Entities;
using Template.DataAccess.Core;



// ref: https://stackoverflow.com/questions/38379360/examples-of-repository-pattern-with-consuming-an-external-rest-web-service-via-h

namespace Template.DataAccess.Core
{
    public class RepositoryWebApi : IRepositoryBase
    {
        private IDistributedCache _distributedCache;

        private static string baseUrl = "http://localhost:13736/api/";

        public RepositoryWebApi(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Delete<T>(object Id) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            // For CQRS if would go here. We want to replace the remote database with something local either redis or other.
            var clientEvents = new List<Event>(); // Thsi was a business object but... oh man. but it's actually a dto from the repository level.
            // I think this goes into the repository.
            var cachedEvents = _distributedCache.Get("Events");

            var deserializeObject = new List<T>();


            if (cachedEvents == null)
            {

                // HTTP Call to domain WebApi - Make Async this stuff.
                var jsonObject = GetStringAsync(baseUrl + typeof(T).Name + "s");
                var json = jsonObject.Result;

                string serializedClientEvents = json;

                //string serializedClientEvents = JsonConvert.SerializeObject(clientEvents);
                byte[] encodeClientEvents = Encoding.UTF8.GetBytes(serializedClientEvents);
                var cacheEntryOptions = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(1000));

                _distributedCache.Set("Events", encodeClientEvents, cacheEntryOptions);

                // return value.
                deserializeObject = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                byte[] encodedClientEvents = _distributedCache.Get("Events");
                string serializedEvents = Encoding.UTF8.GetString(encodedClientEvents);
                //clientEvents = JsonConvert.DeserializeObject<List<Event>>(serializedEvents);
                deserializeObject = JsonConvert.DeserializeObject<List<T>>(serializedEvents);

                //deserializeObject = JsonConvert.DeserializeObject<List<T>>(json);
            }


            return deserializeObject;
        }


        public T GetById<T>(object Id) where T : class
        {
            // Async this stuff.
            var jsonObject = GetStringAsync(baseUrl + "alerts/" + Id);
            var alert = JsonConvert.DeserializeObject<T>(jsonObject.Result);
            return alert; //???
        }
        private static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
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



        //public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        //{
        //    return All<T>().FirstOrDefault(expression);
        //}

        //public IQueryable<T> All<T>() where T : class
        //{
        //    throw new NotImplementedException();
        //    //return _context.Set<T>().AsQueryable();
        //}

        //public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        //{
        //    throw new NotImplementedException();
        //    //return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        //}

        //public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        //{
        //    throw new NotImplementedException();

        //    //int skipCount = index * size;
        //    //var _resetSet = filter != null ? _context.Set<T>().Where<T>(filter).AsQueryable() : _context.Set<T>().AsQueryable();
        //    //_resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //    //total = _resetSet.Count();
        //    //return _resetSet.AsQueryable();
        //}

        //public virtual void Create<T>(T TObject) where T : class
        //{
        //    throw new NotImplementedException();

        //    // var newEntry = _context.Set<T>().Add(TObject); 
        //}

        //public virtual void Delete<T>(T TObject) where T : class
        //{
        //    throw new NotImplementedException();
        //    // _context.Set<T>().Remove(TObject);
        //}

        //public virtual void Update<T>(T TObject) where T : class
        //{
        //    throw new NotImplementedException();

        //    //try
        //    //{
        //    //    var entry = _context.Entry(TObject);
        //    //    _context.Set<T>().Attach(TObject);
        //    //    entry.State = EntityState.Modified;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //}
        //public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        //{
        //    throw new NotImplementedException();
        //    //var objects = Filter<T>(predicate);
        //    //foreach (var obj in objects)
        //    //    _context.Set<T>().Remove(obj);
        //}
        //public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        //{
        //    throw new NotImplementedException();
        //    //return _context.Set<T>().Count<T>(predicate) > 0;
        //}
        //public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        //{
        //    throw new NotImplementedException();
        //    // return _context.Set<T>().FirstOrDefault<T>(predicate);
        //}
        //public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        //{
        //    throw new NotImplementedException();
        //    // _context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        //}

    }
}
