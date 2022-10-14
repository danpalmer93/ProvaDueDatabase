using System.Linq.Expressions;

namespace ProvaDueDatabase.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        T FindById(int id);
        //T FindByName(string name);
        T Delete(T entity);
        T Update(T entity);
    }


}
