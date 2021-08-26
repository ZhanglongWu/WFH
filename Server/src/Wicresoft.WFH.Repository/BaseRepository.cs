namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IDbSet<T> Entry;

        public T Entity { get; private set; }

        public IWorkFromHomeEntities DbContext { get; }

        public BaseRepository(IWorkFromHomeEntities dbContext)
        {
            this.DbContext = dbContext;
            this.Entry = dbContext.SetEntry<T>();
        }

        public async Task<PagedData<T>> QueryAsync(BaseQuery<T> context)
        {
            var query = context.Where(this.Entry);

            var total = await query.CountAsync();

            return new PagedData<T>()
            {
                Total = total,
                Items = query.OrderByDescending(prop => prop.Id).Paging(context.Page, context.PageSize).ToList()
            };
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.Entry.Where(prop => prop.IsActive).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.Entry.FirstOrDefaultAsync(item => item.Id == id && item.IsActive);
        }

        public async Task<T> GetByIdAsync(int id, IEnumerable<Expression<Func<T, object>>> includes)
        {
            var entry = this.Entry.AsQueryable();

            if (includes != null)
            {
                entry = includes.Aggregate(entry, (current, include) => current.Include(include));
            }

            return await entry.FirstOrDefaultAsync(item => item.Id == id && item.IsActive);
        }

        public async Task CreateAsync(T entity)
        {
            this.Entity = entity;
            this.DbContext.SetEntryState(entity, EntityState.Added);
        }

        public async Task UpdateAsync(T entity)
        {
            this.Entity = entity;
            this.DbContext.SetEntryState(entity, EntityState.Modified);
        }

        public async Task DeleteAsync(int id, int operatorId)
        {
            var entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsActive = false;

                await this.UpdateAsync(entity);
            }
        }

        public async Task<T> SaveAsync()
        {
            await this.DbContext.SaveChangesAsync();

            return this.Entity;
        }
    }
}
