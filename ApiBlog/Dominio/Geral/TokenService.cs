using ApiBlog.Dominio.Usuarios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBlog.Dominio.Geral
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string Gerar(Usuario usuario)
        {
            //Cria instancia do JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_config["SecretsConfiguration:JwtKey"]);

            var credencial = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GerarClaims(usuario),
                SigningCredentials = credencial
            };

            //Gera um token
            var token = handler.CreateToken(tokenDescriptor);

            //Gera uma string do token
            return $"Bearer {handler.WriteToken(token)}";
        }

        public static ClaimsIdentity GerarClaims(Usuario usuario)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));

            ci.AddClaim(new Claim("IdUsuario", usuario.Id.ToString(), ClaimValueTypes.String));

            return ci;
        }
    }
}
