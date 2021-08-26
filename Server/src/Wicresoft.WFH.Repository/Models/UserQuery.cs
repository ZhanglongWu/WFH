using Wicresoft.WFH.Core;

namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Core;
    using Wicresoft.WFH.Data;

    public class UserQuery : BaseQuery<User>
    {
        public string Name { get; set; }

        public static IEnumerable<Expression<Func<User, object>>> PermissionNavigation =
            new List<Expression<Func<User, object>>>()
            {
                prop => prop.UserPermissionMaps.Select(map => map.Permission),
                prop => prop.UserRoleMaps.Select(map => map.Role.RolePermissionMaps.Select(item => item.Permission))
            };

        public static Expression<Func<User, object>> RoleNavigation = prop => prop.UserRoleMaps.Select(map => map.Role);

        public static Expression<Func<User, object>> MenuNavigation = prop =>
            prop.UserRoleMaps.Select(map => map.Role.RoleMenuMaps.Select(item => item.Menu.Module));

        public static Expression<Func<User, object>> CreatedUserNavigation = prop => prop.CreatedUser;

        public static Expression<Func<User, object>> UpdatedUserUserNavigation = prop => prop.UpdatedUser;

        public override List<Expression<Func<User, object>>> Includes { get; set; } = new List<Expression<Func<User, object>>>();

        public UserQuery IncludeRole()
        {
            this.Includes.Add(RoleNavigation);

            return this;
        }

        public UserQuery IncludePermission()
        {
            this.Includes.AddRange(PermissionNavigation);

            return this;
        }

        public UserQuery IncludeMenu()
        {
            this.Includes.Add(MenuNavigation);

            return this;
        }

        public UserQuery IncludeCreatedUser()
        {
            this.Includes.Add(CreatedUserNavigation);

            return this;
        }

        public UserQuery IncludeUpdatedUser()
        {
            this.Includes.Add(UpdatedUserUserNavigation);

            return this;
        }

        public UserQuery IncludeAll()
        {
            this.IncludeMenu()
                .IncludePermission()
                .IncludeRole()
                .IncludeCreatedUser()
                .IncludeUpdatedUser();

            return this;
        }

        public static IEnumerable<Expression<Func<User, object>>> GetAllNavigation()
        {
            var includes = new List<Expression<Func<User, object>>> { RoleNavigation, MenuNavigation, CreatedUserNavigation, UpdatedUserUserNavigation };

            includes.AddRange(PermissionNavigation);

            return includes;
        }

        public override Expression<Func<User, bool>> GetQueryExpression()
        {
            Expression<Func<User, bool>> expression = prop => prop.IsActive;

            if (!string.IsNullOrEmpty(this.Name))
            {
                expression = expression.And(prop => prop.Name.Contains(this.Name));
            }

            return expression;
        }
    }
}
