

// This file is auto-generated, do not modify this file.
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Wicresoft.WFH.Core;
using System.Threading.Tasks;
namespace Wicresoft.WFH.Data
{
    public sealed class WorkFromHomeEntities : DbContext, IWorkFromHomeEntities
    {
        public const string ConnectionString = "name=WorkFromHomeEntities";
        public const string ContainerName = "WorkFromHomeEntities";
    
        public void Detach(object obj)
        {
            Entry(obj).State = EntityState.Detached;
        }
        
        public void DiscardChanges()
        {
            _Context.DiscardChanges();
        }
    
        private ObjectContext _Context
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }
    
        #region Constructors
    
        public WorkFromHomeEntities()
            : this(ConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }
    
        public WorkFromHomeEntities(string connectionString, int? commandTimeout = null)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            _Context.CommandTimeout = commandTimeout
                ?? AppSettingsHelper.GetAppSetting("CommandTimeout", 30);
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false; // TODO: until the maxLength attributes are generated in entities
        }
    
    /*
        public WorkFromHomeEntities(EntityConnection connection)
            : base(connection)
        {
            Configuration.LazyLoadingEnabled = true;
        }
    */
    
        #endregion
        
        bool IWorkFromHomeEntities.CanPreCompile
        {
            get { return true; }
        }
    
        #region DbSet Properties
        public IDbSet<AccessEvent> AccessEvents { get; set; }
        public IDbSet<Device> Devices { get; set; }
        public IDbSet<Menu> Menus { get; set; }
        public IDbSet<Module> Modules { get; set; }
        public IDbSet<Organization> Organizations { get; set; }
        public IDbSet<Permission> Permissions { get; set; }
        public IDbSet<RoleMenuMap> RoleMenuMaps { get; set; }
        public IDbSet<RolePermissionMap> RolePermissionMaps { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserPermissionMap> UserPermissionMaps { get; set; }
        public IDbSet<UserRoleMap> UserRoleMaps { get; set; }
        public IDbSet<User> Users { get; set; }

        #endregion

    
        public void SetEntryState<T>(T entry, EntityState state) where T : IdentityEntity
        {
            this.Entry(entry).State = state;
        }
    
    	public IDbSet<T> SetEntry<T>() where T : IdentityEntity
        {
            return this.Set<T>();
        }
    
    	 public override int SaveChanges()
         {
    		this.BeforeSaveChanges();
    		return base.SaveChanges();
         }
    
    	 public override Task<int> SaveChangesAsync()
         {
    		this.BeforeSaveChanges();
    
    		return base.SaveChangesAsync();
         }
    
    	 private void BeforeSaveChanges()
        {
            var now = DateTime.UtcNow;
    
            foreach (var entry in ChangeTracker.Entries()
                .Where(p => p.Entity.GetType().GetProperty("CreatedDateTime") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedDateTime").CurrentValue = now;
                        break;
                    case EntityState.Modified:
                        entry.Property("CreatedDateTime").IsModified = false;
                        break;
                }
            }
    
            foreach (var entry in ChangeTracker.Entries()
                .Where(p => p.Entity.GetType().GetProperty("IsActive") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("IsActive").CurrentValue = true;
                        break;
                }
            }
    
            foreach (var entry in ChangeTracker.Entries().Where(p =>
                (p.State == EntityState.Added || p.State == EntityState.Modified) &&
                p.Entity.GetType().GetProperty("LastUpdatedDateTime") != null))
            {
                entry.Property("LastUpdatedDateTime").CurrentValue = now;
            }
        }
    }
}



