namespace Wicresoft.WFH.Model
{
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class UserViewModel : BaseViewModel
    {
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public bool IsEnable { get; set; }

        public IEnumerable<ModuleViewModel> Modules { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }

        public IEnumerable<PermissionViewModel> Permissions { get; set; }

        public bool CheckPermissions(IEnumerable<PermissionType> permissions)
        {
            if (this.Permissions == null || permissions == null) return false;

            return this.Permissions.Any(item => permissions.Contains((PermissionType)item.Id));
        }
    }
}
