namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Core;
    using Wicresoft.WFH.Data;

    public sealed class RoleQuery : BaseQuery<Role>
    {
        public string Name { get; set; }

        public static Expression<Func<Role, object>> MenuNavigation = prop => prop.RoleMenuMaps.Select(map => map.Menu);
        public static Expression<Func<Role, object>> PermissionNavigation = prop => prop.RolePermissionMaps.Select(map => map.Permission);

        public override List<Expression<Func<Role, object>>> Includes { get; set; } = new List<Expression<Func<Role, object>>>();

        public RoleQuery IncludePermission()
        {
            this.Includes.Add(PermissionNavigation);

            return this;
        }

        public RoleQuery IncludeMenu()
        {
            this.Includes.Add(MenuNavigation);

            return this;
        }

        public RoleQuery IncludeAll()
        {
            this.IncludeMenu().IncludePermission();

            return this;
        }

        public override Expression<Func<Role, bool>> GetQueryExpression()
        {
            Expression<Func<Role, bool>> expression = prop => prop.IsActive;

            if (!string.IsNullOrEmpty(this.Name))
            {
                expression = expression.And(prop => prop.Name.Contains(this.Name));
            }

            return expression;
        }
    }
}
