using Microsoft.IdentityModel.Tokens;
using OrderManagementSystem.Common.General;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace OrderManagementSystem.Api.Authentication
{
    public class JwtAuthentication(string key) : IJwtAuthentication
    {

        #region Actions
        public string Authenticate(string id, DateTime? validTill = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key1 = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("Id", id)
                }),
                Expires = AppDateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key1), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        #endregion
    }
}
