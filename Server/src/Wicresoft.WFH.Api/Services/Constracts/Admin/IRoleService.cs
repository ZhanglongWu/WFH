namespace Wicresoft.WFH.Api
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Repository;

    public interface IRoleService
    {
        Task<IEnumerable<RoleViewModel>> GetAllAsync();
        Task<PagedData<RoleViewModel>> QueryAsync(RoleQuery context);

        Task<RoleViewModel> GetByIdAsync(int id);
        Task<RoleViewModel> CreateAsync(RoleViewModel model, int operatorId);
        Task<RoleViewModel> UpdateAsync(RoleViewModel model, int operatorId);
        Task DeleteAsync(int id, int operatorId);
    }
}
