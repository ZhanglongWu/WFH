namespace Wicresoft.WFH.Repository
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> UpdateMenuAsync(IEnumerable<int> menuIds);
        Task<Role> UpdatePermissionAsync(IEnumerable<int> permissionIds);
    }
}
