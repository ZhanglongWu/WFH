namespace Wicresoft.WFH.Api
{
    using System.Web;

    using Wicresoft.WFH.Common;

    public static class HttpExtension
    {
        public static string GetCurrentIdentifier(this HttpContext context)
        {
            var token = context.Request.Cookies.Get(Content.COOKIE_NAME)?.Value;

            if (string.IsNullOrEmpty(token)) return string.Empty;

            return JwtManager.ValidateToken(token, Configuration.Secret, false)?.Identifier;
        }
    }
}