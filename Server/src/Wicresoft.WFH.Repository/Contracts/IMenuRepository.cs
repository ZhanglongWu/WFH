namespace Wicresoft.WFH.Repository
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public interface IMenuRepository : IBaseRepository<Menu>
    {
        Task<List<Menu>> ExtractMenusAsync(IEnumerable<Permission> permissions);
    }
}
