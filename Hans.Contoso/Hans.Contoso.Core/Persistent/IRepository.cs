using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hans.Contoso.Core.Persistence
{
    public interface IRepository<TDomain> where TDomain : class
    {
        void Save(TDomain instance);
        void Update(TDomain instance);
        void Delete(TDomain instance);
        Task SaveAsync(TDomain instance);
        Task UpdateAsync(TDomain instance);
        Task DeleteAsync(TDomain instance);

        IQueryable<TDomain> FindAll();
        IQueryable<TDomain> FindAllBy(Expression<Func<TDomain, bool>> where);
        TDomain FindOneBy(Expression<Func<TDomain, bool>> where);

        Task<IQueryable<TDomain>> FindAllAsync();
        Task<IQueryable<TDomain>> FindAllByAsync(Expression<Func<TDomain, bool>> where);
        Task<TDomain> FindOneByAsync(Expression<Func<TDomain, bool>> where);
    }
}
