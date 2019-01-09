using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    // NOTE: Covariance ONLY works with Interfaces and delegates
    public interface IRepository<T> : IReadOnlyRepository<T>, IDisposable // put contraints on the implementation NOT THE I/F
    {
        void Add(T newEntity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindAll();
        int Commit();
    }

    public interface IReadOnlyRepository<out T> : IDisposable
    {
        // only include the method that RETURN T... but set T in any way.
        T FindById(int id);
        IQueryable<T> FindAll();
    }


    // DESIGN STYLE: Containts are implementation details. They ought to go on the concretet class rather
    // than the interface (Scott Allen's recommendation)
    // Constraints on the repository; class constraint MUST come first!!! The new() constraint ALWAYS comes last!!!
    public class SqlRepository<T> : IRepository<T> where T: class, IEntity, new()
    // public class SqlRepository<T> : IRepository<T> where T: Person, IEntity
    //public class SqlRepository<T, T2> : IRepository<T> where T: T2, IEntity
    //                                                   where T2: class
    {
        private DbContext _ctx;

        // DbSet requires that T be a class
        private DbSet<T> _set;

        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }


        public void Add(T newEntity)
        {
            if (newEntity.IsValid()) // repo constraint allows this. 
            {
                _set.Add(newEntity);
            }
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Dispose()
        {
            _ctx.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public T FindById(int id)
        {
            // allowed due to NEW() constraint
            //T entity = new T();
            // T entity = default(T);
            return _set.Find(id);
            
        }
    }

}
