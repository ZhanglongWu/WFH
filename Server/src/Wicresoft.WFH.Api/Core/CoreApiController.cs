namespace Wicresoft.WFH.Api
{
    using System.Web;
    using System.Web.Http;
    using System.Threading.Tasks;

    using Unity;

    using Wicresoft.WFH.Model;

    [JwtAuthenticate]
    public class CoreApiController : BaseApiController
    {
        private UserViewModel _currentUser;

        protected UserViewModel CurrentUser
        {
            get
            {
#if DEBUG
                if (this._currentUser == null)
                {
                    this._currentUser = this.GetCurrentUser();
                }
#endif

                return this._currentUser;
            }
        }

        protected UserViewModel GetCurrentUser()
        {
            var email = HttpContext.Current.GetCurrentIdentifier();

            return UnityConfig.RootContainer.Resolve<IUserService>()
                .GetByEmail(email);
        }
    }
}
