namespace Wicresoft.WFH.Api
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Model;

    public interface IPermissionService
    {
        Task<IEnumerable<PermissionViewModel>> GetAllPermissionsAsync();

        Task<IEnumerable<PermissionTreeViewModel>> GetAllPermissionTreesAsync();
    }
}
