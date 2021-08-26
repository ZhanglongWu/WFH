namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public sealed class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        private readonly IWorkFromHomeEntities _dbContext;

        public PermissionRepository(IWorkFromHomeEntities dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await this._dbContext
                .Permissions
                .Where(prop => prop.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllAsync(IEnumerable<Expression<Func<Permission, object>>> includes)
        {
            var entry = this.Entry.AsQueryable();

            if (includes != null)
                entry = includes.Aggregate(entry, (current, expression) => current.Include(expression));

            return await entry.Where(prop => prop.IsActive).ToListAsync();
        }
    }
}
