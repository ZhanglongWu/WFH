namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public abstract class BaseQuery<T> where T : IdentityEntity
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public abstract List<Expression<Func<T, object>>> Includes { get; set; }

        public abstract Expression<Func<T, bool>> GetQueryExpression();

        public virtual IQueryable<T> Where(IQueryable<T> entities)
        {
            if (this.Includes == null) return entities.Where(this.GetQueryExpression());

            foreach (var include in this.Includes)
            {
                entities = entities.Include(include);
            }

            return entities.Where(this.GetQueryExpression());
        }
    }
}
