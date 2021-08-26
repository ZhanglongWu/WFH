namespace Wicresoft.WFH.Repository
{
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public sealed class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IWorkFromHomeEntities dbContext) : base(dbContext)
        {
        }

        public async Task<Role> UpdateMenuAsync(IEnumerable<int> menuIds)
        {
            var maps = await this.DbContext.RoleMenuMaps
                .Where(item => item.RoleId == this.Entity.Id)
                .ToListAsync();

            foreach (var map in maps)
            {
                this.DbContext.SetEntryState(map, EntityState.Deleted);
            }

            if (menuIds == null) return this.Entity;

            foreach (var menuId in menuIds)
            {
                this.DbContext.RoleMenuMaps.Add(new RoleMenuMap() { MenuId = menuId, RoleId = this.Entity.Id });
            }

            return this.Entity;
        }

        public async Task<Role> UpdatePermissionAsync(IEnumerable<int> permissionIds)
        {
            var maps = await this.DbContext.RolePermissionMaps
                .Where(item => item.RoleId == this.Entity.Id)
                .ToListAsync();

            foreach (var map in maps)
            {
                this.DbContext.SetEntryState(map, EntityState.Deleted);
            }

            if (permissionIds == null) return this.Entity;

            foreach (var permissionId in permissionIds)
            {
                this.DbContext.RolePermissionMaps.Add(new RolePermissionMap() { PermissionId = permissionId, RoleId = this.Entity.Id });
            }

            return this.Entity;
        }
    }
}
