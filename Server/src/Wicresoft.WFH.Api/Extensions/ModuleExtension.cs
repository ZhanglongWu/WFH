namespace Wicresoft.WFH.Api
{
    using System.Linq;

    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Model;

    public static class ModuleExtension
    {
        public static ModuleViewModel ToViewModel(this Module entity)
        {
            return new ModuleViewModel()
            {
                Id = entity.Id,
                Key = entity.Key,
                Name = entity.DisplayName,
                Order = entity.Order,
                Menus = entity.Menus?.Select(item => item.ToViewModel()).ToList()
            };
        }
    }
}