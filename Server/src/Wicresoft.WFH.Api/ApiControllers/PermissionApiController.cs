namespace Wicresoft.WFH.Api
{
    using System.Linq;
    using System.Web.Http;
    using System.Threading.Tasks;

    [RoutePrefix("api/permissions")]
    public class PermissionApiController : CoreApiController
    {
        private readonly IPermissionService _permissionService;

        public PermissionApiController(IPermissionService permissionService)
        {
            this._permissionService = permissionService;
        }

        [HttpGet]
        [Route("options")]
        public async Task<IHttpActionResult> GetOptionsAsync()
        {
            return this.SetOkResult((await this._permissionService.GetAllPermissionsAsync())
                .OrderBy(prop => prop.Name)
                .Select(item => item.ToOptionViewModel()));
        }

        [HttpGet]
        [Route("tree/options")]
        public async Task<IHttpActionResult> GetTreeOptionsAsync()
        {
            return this.SetOkResult((await this._permissionService.GetAllPermissionTreesAsync())
                .OrderBy(prop => prop.Menu));
        }
    }
}