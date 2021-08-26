namespace Wicresoft.WFH.Repository
{
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(IWorkFromHomeEntities dbContext) : base(dbContext)
        {
        }

        public async Task<List<Menu>> ExtractMenusAsync(IEnumerable<Permission> permissions)
        {
            var permissionIds = permissions.Select(item => item.Id);

            return await this.Entry
                .Where(item => item.IsActive && item.Permissions.Any(permission =>
                    permission.IsActive && permissionIds.Contains(permission.Id)))
                .ToListAsync();
        }
    }
}
