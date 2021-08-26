// Context interface. This file is auto-generated, do not modify this file.
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Wicresoft.WFH.Data
{
    public partial interface IWorkFromHomeEntities : IDisposable
    {
        bool CanPreCompile { get; }
        void Detach(object entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void DiscardChanges();
        #region DbSet Properties
        IDbSet<AccessEvent> AccessEvents { get; set; }
        IDbSet<Device> Devices { get; set; }
        IDbSet<Menu> Menus { get; set; }
        IDbSet<Module> Modules { get; set; }
        IDbSet<Organization> Organizations { get; set; }
        IDbSet<Permission> Permissions { get; set; }
        IDbSet<RoleMenuMap> RoleMenuMaps { get; set; }
        IDbSet<RolePermissionMap> RolePermissionMaps { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<UserPermissionMap> UserPermissionMaps { get; set; }
        IDbSet<UserRoleMap> UserRoleMaps { get; set; }
        IDbSet<User> Users { get; set; }

        #endregion

        Database Database { get; }
    
        void SetEntryState<T>(T entry, EntityState state) where T : IdentityEntity;
    
    	IDbSet<T> SetEntry<T>() where T : IdentityEntity;
      DbContextConfiguration Configuration { get; }
    }
}

