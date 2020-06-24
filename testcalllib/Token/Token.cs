using testcallLib.Token;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace testcallLib
{

    public class TokenResolve
    {

        public static DB_CTX GetHash => new testcallLib.Token.HashFactoryContext().CreateDbContext();
        public static TokenData CheckToken(LoginData data)
        {
            
            using (var db = GetHash)
            {
                //временно отключим 
                //var user = db.user_hashWhere(.....).FirstOrDefault();
                //if (user == null)
                //{
                //    .....
                //    return null;
                //}
                var user = new user_hash() { phone = "777", user_id = 15 };


                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType,user.user_id+""),
                    new Claim("role","client"),
                    new Claim("name",user.phone),
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);


                return GetToken(claimsIdentity, user);
            }
        }
        static TokenData GetToken(ClaimsIdentity identity, user_hash user)
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromDays(15)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new TokenData
            {
                accessToken = encodedJwt,
                //login = user.phone,
                id = user.user_id
            };
            return response;
        }


        public class AuthOptions
        {
            public const string ISSUER = "AuthServer";
            public const string AUDIENCE = "http://192.168.0.199:50000/";
            const string KEY = "enter_here_very_diff_key_))";
            public const int LIFETIME = 1;
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
        }
    }
}
