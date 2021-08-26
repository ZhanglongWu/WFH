namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IWorkFromHomeEntities dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email, IEnumerable<Expression<Func<User, object>>> includes)
        {
            var entry = this.Entry.AsQueryable();

            if (includes == null)
                return await entry.FirstOrDefaultAsync(item => item.IsActive && item.Email.Equals(email));

            entry = includes.Aggregate(entry, (current, expression) => current.Include(expression));

            return await entry.FirstOrDefaultAsync(item => item.IsActive && item.Email.Equals(email));
        }

        public User GetUserByEmail(string email, IEnumerable<Expression<Func<User, object>>> includes)
        {
            var entry = this.Entry.AsQueryable();

            if (includes == null)
                return entry.FirstOrDefault(item => item.IsActive && item.Email.Equals(email));

            entry = includes.Aggregate(entry, (current, expression) => current.Include(expression));

            return entry.FirstOrDefault(item => item.IsActive && item.Email.Equals(email));
        }

        public async Task<User> UpdateRoleAsync(IEnumerable<int> roleIds)
        {
            var maps = await this.DbContext.UserRoleMaps
                .Where(prop => prop.UserId == this.Entity.Id)
                .ToListAsync();

            foreach (var map in maps)
            {
                this.DbContext.SetEntryState(map, EntityState.Deleted);
            }

            if (roleIds == null) return this.Entity;

            foreach (var roleId in roleIds)
            {
                this.DbContext.UserRoleMaps.Add(new UserRoleMap() { UserId = this.Entity.Id, RoleId = roleId });
            }

            return this.Entity;
        }

        public async Task<User> UpdatePermissionAsync(IEnumerable<int> permissionIds)
        {
            var maps = await this.DbContext.UserPermissionMaps
                .Where(prop => prop.UserId == this.Entity.Id)
                .ToListAsync();

            foreach (var map in maps)
            {
                this.DbContext.SetEntryState(map, EntityState.Deleted);
            }

            if (permissionIds == null) return this.Entity;

            foreach (var permissionId in permissionIds)
            {
                this.DbContext.UserPermissionMaps.Add(new UserPermissionMap() { UserId = this.Entity.Id, PermissionId = permissionId });
            }

            return this.Entity;
        }
    }
}
