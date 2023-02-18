using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartTestTask.CQRS.Auth.Queries
{
    public class GetTokenQuery : IRequest<string>
    {
    }

    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IConfiguration _configuration;
        public GetTokenQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var SecretKey = _configuration["Auth:SecretKey"];

            if (SecretKey == null || SecretKey == string.Empty)
            {
                return "";
            }

            byte[] secretBytes = Encoding.UTF8.GetBytes(SecretKey);
            var key = new SymmetricSecurityKey(secretBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, "Test User")
            };

            var token = new JwtSecurityToken(
                _configuration["Auth:Issuer"], _configuration["Auth:Audience"], claims, DateTime.Now, DateTime.Now.AddMonths(12), signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
