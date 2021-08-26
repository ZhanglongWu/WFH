namespace Wicresoft.WFH.Api
{
    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Model;

    public static class MenuExtension
    {
        public static MenuViewModel ToViewModel(this Menu entity)
        {
            if (entity == null) return null;

            return new MenuViewModel()
            {
                Id = entity.Id,
                Order = entity.Order,
                Key = entity.Key,
                Name = entity.Name,
                Icon = entity.Icon,
                Path = entity.Path,
                IsEnable = entity.IsEnable
            };
        }
    }
}