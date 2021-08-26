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

    public sealed class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMenuRepository _menuRepository;

        public RoleService(IRoleRepository roleRepository, IMenuRepository menuRepository)
        {
            this._roleRepository = roleRepository;
            this._menuRepository = menuRepository;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllAsync()
        {
            return (await this._roleRepository.GetAllAsync()).Select(item => item.ToViewModel());
        }

        public async Task<PagedData<RoleViewModel>> QueryAsync(RoleQuery context)
        {
            context.IncludeAll();

            var query = await this._roleRepository.QueryAsync(context);

            return new PagedData<RoleViewModel>()
            {
                Total = query.Total,
                Items = query.Items.Select(item => item.ToViewModel())
            };
        }

        public async Task<RoleViewModel> GetByIdAsync(int id)
        {
            return (await this._roleRepository.GetByIdAsync(id,
                new List<Expression<Func<Role, object>>>() {RoleQuery.PermissionNavigation})).ToViewModel();
        }

        public async Task<RoleViewModel> CreateAsync(RoleViewModel model, int operatorId)
        {
            var entity = model.ToEntity(operatorId);

            await this._roleRepository.CreateAsync(entity);
            await this._roleRepository.UpdateMenuAsync(await this.ExtractMenuIdAsync(model.Permissions));
            await this._roleRepository.UpdatePermissionAsync(model.Permissions.Select(item => item.Id));

            return await this.GetByIdAsync((await this._roleRepository.SaveAsync()).Id);
        }

        public async Task<RoleViewModel> UpdateAsync(RoleViewModel model, int operatorId)
        {
            var entity = await this._roleRepository.GetByIdAsync(model.Id,
                new List<Expression<Func<Role, object>>>() {RoleQuery.PermissionNavigation});

            if (entity == null)
            {
                throw new EntityNotFoundException($@"未找到 XXXX");
            }

            var newEntity = model.MergeEntity(entity, operatorId);

            await this._roleRepository.UpdateAsync(newEntity);
            await this._roleRepository.UpdateMenuAsync(await this.ExtractMenuIdAsync(model.Permissions));
            await this._roleRepository.UpdatePermissionAsync(model.Permissions.Select(item => item.Id));

            return await this.GetByIdAsync((await this._roleRepository.SaveAsync()).Id);
        }

        public async Task DeleteAsync(int id, int operatorId)
        {
            await this._roleRepository.DeleteAsync(id, operatorId);
            await this._roleRepository.SaveAsync();
        }

        private async Task<List<int>> ExtractMenuIdAsync(IEnumerable<PermissionViewModel> models)
        {
            return (await this._menuRepository.ExtractMenusAsync(models.Select(item => item.ToEntity())))
                .Select(item => item.Id).ToList();
        }
    }
}