namespace Wicresoft.WFH.Api
{
    using System;
    using System.Net;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;
    using System.Collections.Generic;
    using System.Web.Http.Controllers;

    using Unity;

    using Wicresoft.WFH.Model;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AccessibleAttribute : AuthorizationFilterAttribute
    {
        public List<PermissionType> AllowPermissions { get; private set; }

        public AccessibleAttribute(params PermissionType[] allowPermissions)
        {
            this.AllowPermissions = allowPermissions.ToList();
        }

        public override async Task OnAuthorizationAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            var user = await GetCurrentUserAsync(actionContext.RequestContext);

            if (user == null || !user.CheckPermissions(this.AllowPermissions))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK,
                    new Result<object>() {IsSuccess = false, Message = "未授权", ErrorCode = ErrorCode.Forbidden});
            }
        }

        private async static Task<string> GetCurrentIdentityAsync(HttpRequestContext context)
        {
            if (context?.Principal == null) return string.Empty;

            return context.Principal.GetUserIdentity();
        }

        private static async Task<UserViewModel> GetCurrentUserAsync(HttpRequestContext context)
        {
            var identity = await GetCurrentIdentityAsync(context);
            if (string.IsNullOrEmpty(identity)) return null;

            return await UnityConfig.RootContainer.Resolve<IUserService>().GetByIdentityAsync(identity);
        }
    }
}