namespace Wicresoft.WFH.Common
{
    using System;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;

    using Microsoft.IdentityModel.Tokens;

    public static class JwtManager
    {
        public static string GenerateToken(string identifier, string secret)
        {
            var symmetricKey = Convert.FromBase64String(secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, identifier) }),
                Expires = DateTime.Now.AddHours(2), //6小时后过期
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public static TokenValidationResult ValidateToken(string token, string secret, bool validateLifetime = true)
        {
            var simplePrinciple = GetPrincipal(token, secret, validateLifetime);

            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null) return new TokenValidationResult() { IsValid = false, Identifier = string.Empty };

            if (!identity.IsAuthenticated) return new TokenValidationResult() { IsValid = false, Identifier = string.Empty };

            var identifier = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return string.IsNullOrEmpty(identifier) ? new TokenValidationResult() { IsValid = false, Identifier = string.Empty } : new TokenValidationResult() { IsValid = true, Identifier = identifier };
        }

        public static ClaimsPrincipal GetPrincipal(string token, string secret, bool validateLifetime = true)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null) return null;

                var symmetricKey = Convert.FromBase64String(secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = validateLifetime,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;

                return tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
