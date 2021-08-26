namespace Wicresoft.WFH.Api
{
    using System;
    using System.Linq;

    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Model;

    public static class RoleExtension
    {
        public static RoleViewModel ToViewModel(this Role entity)
        {
            if (entity == null) return null;

            return new RoleViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                CreatedDateTime = entity.CreatedDateTime,
                LastUpdatedDateTime = entity.LastUpdatedDateTime,
                Permissions = entity.RolePermissionMaps?.Where(item => item.Permission != null && item.Permission.IsActive).Select(item => item.Permission.ToViewModel()).ToList()
            };
        }

        public static Role ToEntity(this RoleViewModel model, int operatorId)
        {
            return model?.MergeEntity(null, operatorId);
        }

        public static Role MergeEntity(this RoleViewModel model, Role entity, int operatorId)
        {
            entity = entity ?? new Role() { IsActive = true, CreatedDateTime = DateTime.UtcNow, CreatedUserId = operatorId };

            entity.Name = model.Name;
            entity.DisplayName = model.DisplayName;
            entity.Description = model.Description;
            entity.LastUpdatedDateTime = DateTime.UtcNow;
            entity.LastUpdatedUserId = operatorId;

            return entity;
        }

        public static OptionViewModel ToOptionViewModel(this RoleViewModel model)
        {
            return new OptionViewModel() { Id = model.Id, Name = model.Name };
        }
    }
}