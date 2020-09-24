using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace GrpcMeasure
{
    public static class Security
    {
        public static readonly JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();
        public static readonly SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());
    }
}
