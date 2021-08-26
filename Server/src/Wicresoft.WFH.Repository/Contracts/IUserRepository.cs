namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email, IEnumerable<Expression<Func<User, object>>> includes);
        User GetUserByEmail(string email, IEnumerable<Expression<Func<User, object>>> includes);
        Task<User> UpdateRoleAsync(IEnumerable<int> roleIds);
        Task<User> UpdatePermissionAsync(IEnumerable<int> permissionIds);
    }
}
