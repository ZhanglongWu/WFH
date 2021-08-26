namespace Wicresoft.WFH.Api
{
    using System;
    using System.Web;
    using System.Threading;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;
    using System.Net.Http.Headers;
    using System.Security.Authentication;

    using Unity;

    using Microsoft.IdentityModel.Tokens;

    using static System.String;

    using Wicresoft.WFH.Common;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class JwtAuthenticateAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            try
            {
                var principal = GetClaimsPrincipalAsync(context);
                if (principal != null)
                {
                    context.Principal = principal;
                }
                else
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", context.Request);
                }
            }
            catch (Exception e)
            {
                context.ErrorResult = new AuthenticationFailureResult(e.Message, context.Request);
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Basic");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);

            return Task.FromResult(0);
        }

        private static ClaimsPrincipal GetClaimsPrincipalAsync(HttpAuthenticationContext context)
        {
            try
            {
                var principal = GetClaimsPrincipalFromCookie() ?? GetClaimsPrincipalFromHeader(context);

                if (principal == null) throw new AuthenticationException("Invalid credentials");

                return principal;
            }
            catch (AuthenticationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new AuthenticationException("Invalid credentials");
            }
        }

        private static ClaimsPrincipal GetClaimsPrincipalFromCookie()
        {
            var token = HttpContext.Current?.Request.Cookies.Get(Content.COOKIE_NAME)?.Value;

            if (IsNullOrEmpty(token)) return null;

            try
            {
                return GetPrincipal(token);
            }
            catch (SecurityTokenExpiredException e)
            {
                token = ReGenerateToken(token);
                if (IsNullOrEmpty(token)) return null;

                HttpContext.Current.Response.Cookies.Set(new HttpCookie(Content.COOKIE_NAME, token) { HttpOnly = true });

                return GetPrincipal(token);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static ClaimsPrincipal GetClaimsPrincipalFromHeader(HttpAuthenticationContext context)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization?.Scheme != "Basic" || IsNullOrEmpty(authorization.Parameter))
            {
                return null;
            }

            return GetPrincipal(authorization.Parameter);
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                return JwtManager.GetPrincipal(token, Configuration.Secret);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static string ReGenerateToken(string old)
        {
            try
            {
                var principal = JwtManager.GetPrincipal(old, Configuration.Secret, false);

                return (principal.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            catch (Exception e)
            {
                return Empty;
            }
        }
    }
}