namespace Wicresoft.WFH.Api
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Wicresoft.WFH.Core;
    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Model;

    public static class UserExtension
    {
        public static UserViewModel ToViewModel(this User entity)
        {
            if (entity == null) return null;

            return new UserViewModel()
            {
                Id = entity.Id,
                Alias = entity.Alias,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                IsEnable = entity.IsEnable,
                CreatedUser = entity.CreatedUser != null ? new UserViewModel() { Id = entity.CreatedUser.Id, Name = entity.CreatedUser.Name } : null,
                CreatedDateTime = entity.CreatedDateTime,
                LastUpdatedUser = entity.UpdatedUser != null ? new UserViewModel() { Id = entity.UpdatedUser.Id, Name = entity.UpdatedUser.Name } : null,
                LastUpdatedDateTime = entity.LastUpdateDateTime,
                Modules = entity.GetModules(),
                Roles = entity.GetRoles(),
                Permissions = entity.GetPermissions()
            };
        }

        public static User ToEntity(this UserViewModel model, int operatorId)
        {
            return model.MergeEntity(null, operatorId);
        }

        public static User MergeEntity(this UserViewModel model, User entity, int operatorId)
        {
            entity = entity ?? new User()
            {
                IsActive = true,
                IsEnable = true,
                CreatedDateTime = DateTime.UtcNow,
                CreatedUserId = operatorId,
                Password = "Password01!".MD5()
            };

            entity.Alias = model.Alias;
            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.LastUpdateDateTime = DateTime.UtcNow;
            entity.LastUpdatedUserId = operatorId;

            return entity;
        }

        public static List<ModuleViewModel> GetModules(this User entity)
        {
            if (entity.UserRoleMaps == null || !entity.UserRoleMaps.Any(item => item.Role != null && item.Role.IsActive))
                return new List<ModuleViewModel>();

            var menus = entity.UserRoleMaps.Where(item => item.Role.IsActive).SelectMany(item =>
                item.Role.RoleMenuMaps.Where(prop => prop.Menu.IsActive && prop.Menu.Module.IsActive)
                    .Select(map => map.Menu)).ToList();

            return menus.GroupBy(prop => prop.Module.Id).Select(item =>
            {
                var module = item.FirstOrDefault().Module.ToViewModel();

                module.Menus = item.Select(prop => prop.ToViewModel()).ToList();

                return module;
            }).ToList();
        }

        public static List<RoleViewModel> GetRoles(this User entity)
        {
            var roles = entity.UserRoleMaps?.Where(prop => prop.Role != null && prop.Role.IsActive)
                .Select(item => item.Role)
                .ToList();

            return roles?.Select(item => item.ToViewModel()).ToList();
        }

        public static List<PermissionViewModel> GetPermissions(this User entity)
        {
            var permissions = new List<PermissionViewModel>();

            if (entity.UserPermissionMaps != null && entity.UserPermissionMaps.Any(item => item.Permission != null && item.Permission.IsActive))
            {
                permissions.AddRange(entity.UserPermissionMaps.Select(item => item.Permission.ToViewModel()));
            }

            if (entity.UserRoleMaps != null &&
                entity.UserRoleMaps.Any(item => item.Role != null && item.Role.IsActive && item.Role.RolePermissionMaps != null))
            {
                permissions.AddRange(entity.UserRoleMaps.SelectMany(map =>
                    map.Role.RolePermissionMaps.Where(prop => prop.Permission.IsActive)
                        .Select(item => item.Permission.ToViewModel())));
            }

            return permissions.Distinct().ToList();
        }
    }
}