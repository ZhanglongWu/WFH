namespace Wicresoft.WFH.Api
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Repository;

    [RoutePrefix("api/roles")]
    public class RoleApiController : CoreApiController
    {
        private readonly IRoleService _roleService;

        public RoleApiController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpPost]
        [Route("query")]
        [Accessible(PermissionType.ViewRole)]
        public async Task<IHttpActionResult> QueryAsync([FromBody] RoleQuery context)
        {
            return this.SetOkResult(await this._roleService.QueryAsync(context));
        }

        [HttpGet]
        [Route("{id}")]
        [Accessible(PermissionType.ViewRole)]
        public async Task<IHttpActionResult> GetAsync([FromUri] int id)
        {
            return this.SetOkResult(await this._roleService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        [Accessible(PermissionType.CreateRole)]
        public async Task<IHttpActionResult> CreateAsync([FromBody] RoleViewModel model)
        {
            return this.SetOkResult(await this._roleService.CreateAsync(model, this.CurrentUser.Id));
        }

        [HttpPut]
        [Route("")]
        [Accessible(PermissionType.UpdateRole)]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] RoleViewModel model)
        {
            return this.SetOkResult(await this._roleService.UpdateAsync(model, this.CurrentUser.Id));
        }

        [HttpDelete]
        [Route("{id}")]
        [Accessible(PermissionType.DeleteRole)]
        public async Task<IHttpActionResult> DeleteAsync([FromUri] int id)
        {
            await this._roleService.DeleteAsync(id, this.CurrentUser.Id);

            return this.SetOkResult();
        }

        [HttpGet]
        [Route("options")]
        public async Task<IHttpActionResult> GetOptionsAsync()
        {
            return this.SetOkResult(
                (await this._roleService.GetAllAsync()).OrderBy(prop => prop.Name)
                .Select(item => item.ToOptionViewModel()));
        }
    }
}
