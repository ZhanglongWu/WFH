// This file is auto-generated, do not modify this file.
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
namespace Wicresoft.WFH.Data
{
    public  abstract class FakeWorkFromHomeEntitiesBase : IWorkFromHomeEntities
    {
        public virtual bool CanPreCompile
        {
            get { return false; }
        }
        public virtual void Detach(object obj)
        {
        }
            #region DbSet Properties
    
        public IDbSet<AccessEvent> AccessEvents { 
        get { return __accessEvents ?? (__accessEvents = new FakeDbSet<AccessEvent>()); }
        set { __accessEvents = value; }
        }
        private IDbSet<AccessEvent> __accessEvents;
    
        public IDbSet<Device> Devices { 
        get { return __devices ?? (__devices = new FakeDbSet<Device>()); }
        set { __devices = value; }
        }
        private IDbSet<Device> __devices;
    
        public IDbSet<Menu> Menus { 
        get { return __menus ?? (__menus = new FakeDbSet<Menu>()); }
        set { __menus = value; }
        }
        private IDbSet<Menu> __menus;
    
        public IDbSet<Module> Modules { 
        get { return __modules ?? (__modules = new FakeDbSet<Module>()); }
        set { __modules = value; }
        }
        private IDbSet<Module> __modules;
    
        public IDbSet<Organization> Organizations { 
        get { return __organizations ?? (__organizations = new FakeDbSet<Organization>()); }
        set { __organizations = value; }
        }
        private IDbSet<Organization> __organizations;
    
        public IDbSet<Permission> Permissions { 
        get { return __permissions ?? (__permissions = new FakeDbSet<Permission>()); }
        set { __permissions = value; }
        }
        private IDbSet<Permission> __permissions;
    
        public IDbSet<RoleMenuMap> RoleMenuMaps { 
        get { return __roleMenuMaps ?? (__roleMenuMaps = new FakeDbSet<RoleMenuMap>()); }
        set { __roleMenuMaps = value; }
        }
        private IDbSet<RoleMenuMap> __roleMenuMaps;
    
        public IDbSet<RolePermissionMap> RolePermissionMaps { 
        get { return __rolePermissionMaps ?? (__rolePermissionMaps = new FakeDbSet<RolePermissionMap>()); }
        set { __rolePermissionMaps = value; }
        }
        private IDbSet<RolePermissionMap> __rolePermissionMaps;
    
        public IDbSet<Role> Roles { 
        get { return __roles ?? (__roles = new FakeDbSet<Role>()); }
        set { __roles = value; }
        }
        private IDbSet<Role> __roles;
    
        public IDbSet<UserPermissionMap> UserPermissionMaps { 
        get { return __userPermissionMaps ?? (__userPermissionMaps = new FakeDbSet<UserPermissionMap>()); }
        set { __userPermissionMaps = value; }
        }
        private IDbSet<UserPermissionMap> __userPermissionMaps;
    
        public IDbSet<UserRoleMap> UserRoleMaps { 
        get { return __userRoleMaps ?? (__userRoleMaps = new FakeDbSet<UserRoleMap>()); }
        set { __userRoleMaps = value; }
        }
        private IDbSet<UserRoleMap> __userRoleMaps;
    
        public IDbSet<User> Users { 
        get { return __users ?? (__users = new FakeDbSet<User>()); }
        set { __users = value; }
        }
        private IDbSet<User> __users;

            #endregion

    
        public abstract int SaveChanges();
        public abstract Task<int> SaveChangesAsync();
        public abstract void DiscardChanges();
    
        public DbContextConfiguration Configuration { get; }
    
        public Database Database
        {
            get { throw new NotImplementedException(); }
        }
    
        public void SetEntryState<T>(T entry, EntityState state) where T : IdentityEntity
        {
            throw new NotImplementedException();
        }
    
    	public IDbSet<T> SetEntry<T>() where T : IdentityEntity
        {
           throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}

