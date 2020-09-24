using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GrpcMeasure
{
    public class AuthService : Auth.AuthBase
    {
        private readonly ILogger<MeasureService> _logger;
        public AuthService(ILogger<MeasureService> logger)
        {
            _logger = logger;
        }


        public override Task<TokenReply> GetToken(TokenRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new InvalidOperationException("Name is not specified.");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, request.Name) };
            var credentials = new SigningCredentials(Security.SecurityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("Coding4Fun", "Coding4FunApp", claims, expires: DateTime.Now.AddSeconds(60), signingCredentials: credentials);
            var tokenCompact = Security.JwtTokenHandler.WriteToken(token);
            var response = new TokenReply()
            {
                Token = tokenCompact
            };
            return Task.FromResult(response); 
        }
    }
}
