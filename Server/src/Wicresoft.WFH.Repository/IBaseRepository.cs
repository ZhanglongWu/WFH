namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public interface IBaseRepository<T> where T : IdentityEntity
    {
        IWorkFromHomeEntities DbContext { get; }

        Task<PagedData<T>> QueryAsync(BaseQuery<T> context);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(int id, IEnumerable<Expression<Func<T, object>>> includes);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id, int operatorId);

        Task<T> SaveAsync();
    }
}
