using chatapp.Dtos;
using chatapp.Infrastructure.Options_Objects;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace chatapp.Infrastructure.Services
{
    public class JWTTokenGenerator
    {
        private readonly JWTSettings _jwtSettings;

        public JWTTokenGenerator(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }


        public string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));

            //  this way of constucting an object is called an object initializer;
            //  this only works with attributes that have public getter and setter,
            // or attributes which are public
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsIdentity CreateClaimsIdentity(Contact contact)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("contact_id", contact.contact_id.ToString()),
                new Claim("first_name", contact.first_name),
                new Claim("last_name", contact.last_name),
                new Claim("username", contact.username),
                new Claim("email", contact.email)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            return claimsIdentity;
        }
    }
}
