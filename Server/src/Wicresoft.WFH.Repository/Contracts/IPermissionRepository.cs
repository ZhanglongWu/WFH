namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<IEnumerable<Permission>> GetAllAsync(IEnumerable<Expression<Func<Permission, object>>> includes);
    }
}
