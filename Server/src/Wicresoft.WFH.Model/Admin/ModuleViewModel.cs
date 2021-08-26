namespace Wicresoft.WFH.Model
{
    using System.Collections.Generic;

    public class ModuleViewModel : BaseViewModel
    {
        public int Order { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public List<MenuViewModel> Menus { get; set; }
    }
}
