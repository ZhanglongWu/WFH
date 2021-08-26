namespace Wicresoft.WFH.Model
{
    using System.Collections.Generic;

    public class RoleViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public IEnumerable<MenuViewModel> Menus { get; set; }

        public IEnumerable<PermissionViewModel> Permissions { get; set; }
    }
}
