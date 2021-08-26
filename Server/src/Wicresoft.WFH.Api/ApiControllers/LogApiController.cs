namespace Wicresoft.WFH.Api
{
    using System;
    using System.Web.Http;
    using System.Threading.Tasks;

    [RoutePrefix("api/logs")]
    public class LogApiController : CoreApiController
    {
        private readonly IAccessService _accessService;

        public LogApiController(IAccessService accessService)
        {
            this._accessService = accessService;
        }

        [HttpPost]
        [Route("access-info")]
        public async Task<IHttpActionResult> LogAccessInfoAsync([FromUri] string path)
        {
            try
            {
                await this._accessService.CreateAccessEventAsync(path, this.CurrentUser?.Id, this.Request.GetIpAddress());

                return this.SetOkResult();
            }
            catch (Exception e)
            {
                return this.SetBadResult(e);
            }
        }
    }
}