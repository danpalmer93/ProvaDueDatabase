using Microsoft.EntityFrameworkCore;
using ProvaDueDatabase.Data;
using System.Linq.Expressions;

namespace ProvaDueDatabase.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public ProvaDueContext context;

        public Repository(ProvaDueContext Context)
        {
            this.context = Context;
        }

        public T Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges ();
            return entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public T FindById(int id)
        {
            return context.Find<T>(id);
        }

        //public T FindByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}
