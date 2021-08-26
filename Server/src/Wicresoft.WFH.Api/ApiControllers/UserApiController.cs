namespace Wicresoft.WFH.Api
{
    using System.Web.Http;
    using System.Threading.Tasks;

    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Repository;

    [RoutePrefix("api/users")]
    public class UserApiController : CoreApiController
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("query")]
        [Accessible(PermissionType.ViewUser)]
        public async Task<IHttpActionResult> QueryAsync([FromBody] UserQuery context)
        {
            return this.SetOkResult(await this._userService.QueryAsync(context));
        }

        [HttpGet]
        [Route("{id}")]
        [Accessible(PermissionType.ViewUser)]
        public async Task<IHttpActionResult> GetAsync([FromUri] int id)
        {
            return this.SetOkResult(await this._userService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        [Accessible(PermissionType.CreateUser)]
        public async Task<IHttpActionResult> CreateAsync([FromBody] UserViewModel model)
        {
            return this.SetOkResult(await this._userService.CreateAsync(model, this.CurrentUser.Id));
        }

        [HttpPut]
        [Route("")]
        [Accessible(PermissionType.UpdateUser)]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] UserViewModel model)
        {
            return this.SetOkResult(await this._userService.UpdateAsync(model, this.CurrentUser.Id));
        }

        [HttpDelete]
        [Route("{id}")]
        [Accessible(PermissionType.DeleteUser)]
        public async Task<IHttpActionResult> DeleteAsync([FromUri] int id)
        {
            await this._userService.DeleteAsync(id, this.CurrentUser.Id);

            return this.SetOkResult();
        }
    }
}
