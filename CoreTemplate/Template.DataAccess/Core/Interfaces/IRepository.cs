using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.DataAccess.Core;

namespace Template.DataAccess.Core
{
    // Why IQuerable should not be in a repository
    // https://weblogs.asp.net/dotnetstories/repository-iqueryable
    // Let's say that you write something like that in your Services layer which sits on the top of the domain layer.
    // var BestSellerBooks = context.Books.Where(b => b.isPublished && b.AuthorLastName = "Hemingway");

    // Let's examine what we get back here. Without a shadow of a doubt we get back an IQueryable<Book> which is an 
    // entity from the entity framework, meaning we use the Entity Framework inside our Applications or Services layer.
    // That is a leaky abstraction and a violation of separation of concerns principle. 
    // We have the Services layer tightly coupled to the underlying ORM which is EF in our case.

    // The alternative
    //public interface IRepositoryBase<T> where T : class
    //{
    //    IEnumerable<T> GetAll();
    //    T GetById(object Id);
    //    T Insert(T obj);
    //    void Delete(object Id);
    //    T Update(T obj);
    //    void Save();
    //}

    // The alternative strait crud, another version.
    public interface IRepositoryBase
    {
        IEnumerable<T> GetAll<T>() where T : class;
        T GetById<T>(object Id) where T : class;
        T Insert<T>(T obj) where T : class;
        void Delete<T>(object Id) where T : class;
        T Update<T>(T obj) where T : class;
        void Save<T>() where T : class;
    }

    public interface IRepository
    {
        //IQueryable<T> All<T>() where T : class; // IQueryable? WebApi or Mongo will not have that.
        IEnumerable<T> All<T>() where T : class; // IQueryable? WebApi or Mongo will not have that.
        void Create<T>(T TObject) where T : class;
        void Delete<T>(T TObject) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Update<T>(T TObject) where T : class;
        void ExecuteProcedure(string procedureCommand, params SqlParameter[] sqlParams);
        IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class;
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        T Single<T>(Expression<Func<T, bool>> expression) where T : class;
        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
