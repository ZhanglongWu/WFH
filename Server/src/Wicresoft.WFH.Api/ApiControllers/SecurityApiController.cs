namespace Wicresoft.WFH.Api
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Common;

    [RoutePrefix("api/security")]
    public class SecurityApiController : BaseApiController
    {
        private readonly IUserService _userService;

        public SecurityApiController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> LoginAsync([FromBody] LoginModel context)
        {
            try
            {
                var model = await this._userService.LoginAsync(context.Email, context.Password);

                var token = JwtManager.GenerateToken(model.Email, Api.Configuration.Secret);

                HttpContext.Current.Response.SetCookie(new HttpCookie(Api.Content.COOKIE_NAME, token) { HttpOnly = true });

                return this.SetOkResult(new
                {
                    IsSuccess = true,
                    User = model,
                    AccessToken = new { Token = token, ExpireIn = DateTime.UtcNow.AddHours(2) }
                });
            }
            catch (LoginException ex)
            {
                return this.SetBadResult(ex);
            }
            catch (Exception e)
            {
                return this.SetBadResult(e);
            }
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IHttpActionResult> LogoutAsync()
        {
            HttpContext.Current.Response.Cookies.Clear();

            return this.SetOkResult();
        }

        [HttpGet]
        [Route("current")]
        public async Task<IHttpActionResult> GetCurrentAsync()
        {
            try
            {
                return this.SetOkResult(await this.GetUserInformationAsync());
            }
            catch (Exception e)
            {
                return this.SetBadResult(e);
            }
        }

        [HttpPost]
        [Route("update-password")]
        public async Task<IHttpActionResult> ChangePasswordAsync(PasswordEditModel context)
        {
            var user = await this.GetUserInformationAsync();

            if (user == null) return this.SetBadResult(new Exception("系统错误，请联系管理员"));

            try
            {
                await this._userService.ChangePasswordAsync(user.Id, context);

                return this.SetOkResult();
            }
            catch (Exception e)
            {
                return this.SetBadResult(e);
            }
        }

        private async Task<UserViewModel> GetUserInformationAsync()
        {
            var email = HttpContext.Current.GetCurrentIdentifier();

            if (string.IsNullOrEmpty(email)) return null;

            return await this._userService.GetByEmailAsync(email);
        }
    }
}