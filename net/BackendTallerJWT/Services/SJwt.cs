using BackendTaller.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace BackendTaller.Services
{
    public class SJwt : IJwt
    {
        private readonly string _key;

        public SJwt(string key)
        {
            _key = key;
        }

        public string auth(string username, string password)
        {
            string token = string.Empty;

            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }


            if(username == "admin" && password == "123456" )
            {

                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.ASCII.GetBytes(_key);

                var tokendescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = new ClaimsIdentity(
                        
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.Email, "vpr@email.com"),
                            new Claim(ClaimTypes.Role, "admin"),
                        }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
                };

                var constjwt = tokenhandler.CreateToken(tokendescriptor);

                token = tokenhandler.WriteToken(constjwt);

            }

            return token;

        }

    }
}
