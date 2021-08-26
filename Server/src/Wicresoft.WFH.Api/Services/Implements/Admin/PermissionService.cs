namespace Wicresoft.WFH.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Repository;

    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            this._permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionViewModel>> GetAllPermissionsAsync()
        {
            return (await this._permissionRepository.GetAllAsync()).Select(item => item.ToViewModel());
        }

        public async Task<IEnumerable<PermissionTreeViewModel>> GetAllPermissionTreesAsync()
        {
            return (await this._permissionRepository.GetAllAsync(new List<Expression<Func<Permission, object>>>()
            {
                prop => prop.Menu
            })).ToTreeViewModels();
        }
    }
}