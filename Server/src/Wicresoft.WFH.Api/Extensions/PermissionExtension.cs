namespace Wicresoft.WFH.Api
{
    using System.Linq;
    using System.Collections.Generic;

    using Wicresoft.WFH.Core;
    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Model;

    public static class PermissionExtension
    {
        public static PermissionViewModel ToViewModel(this Permission entity)
        {
            if (entity == null) return null;

            return new PermissionViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description
            };
        }

        public static List<PermissionTreeViewModel> ToTreeViewModels(this IEnumerable<Permission> entities)
        {
            if (!Check.IsNotNull(entities)) return null;

            return entities
                .Where(prop => prop.IsActive)
                .GroupBy(prop => prop.MenuId)
                .Select(item => new PermissionTreeViewModel()
                {
                    Menu = item.FirstOrDefault()?.Menu?.Name,
                    Permissions = item.Select(prop => prop.ToViewModel()).ToList()
                })
                .ToList();
        }

        public static Permission ToEntity(this PermissionViewModel model)
        {
            if (!Check.IsNotNull(model)) return null;

            return new Permission()
            {
                Id = model.Id,
                Name = model.Name,
                DisplayName = model.DisplayName
            };
        }
    }
}