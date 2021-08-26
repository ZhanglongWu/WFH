namespace Wicresoft.WFH.Api
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;

    public static class ClaimsIdentityExtensions
    {
        public static ClaimsIdentity AsClaimsIdentity(this IIdentity identity)
        {
            return identity as ClaimsIdentity;
        }

        public static string GetUserIdentity(this IPrincipal user)
        {
            return GetUserProperty(user, ClaimTypes.NameIdentifier);
        }

        public static void CleanClaim(this IPrincipal user)
        {
            var claim = GetClaim(user, ClaimTypes.NameIdentifier);

            if (claim == null) return;

            var identity = user?.Identity.AsClaimsIdentity();

            identity?.RemoveClaim(claim);
        }

        private static string GetUserProperty(IPrincipal user, string property)
        {
            var identity = user?.Identity.AsClaimsIdentity();

            if (identity == null) return string.Empty;

            var claim = GetClaim(user, property);

            return claim?.Value ?? string.Empty;
        }

        private static Claim GetClaim(IPrincipal user, string claim)
        {
            var identity = user?.Identity.AsClaimsIdentity();

            return identity?.Claims.FirstOrDefault(
                item => item.Type.Equals(claim, StringComparison.OrdinalIgnoreCase));
        }
    }
}