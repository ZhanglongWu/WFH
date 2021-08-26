namespace Wicresoft.WFH.Model
{
    using System.Collections.Generic;

    public class MenuViewModel : BaseViewModel
    {
        public short Order { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        public bool IsEnable { get; set; }

        public List<MenuViewModel> Children { get; set; }
    }
}
