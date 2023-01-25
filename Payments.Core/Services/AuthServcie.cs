using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Payments.Core.CustomEntities;
using Payments.Core.Entities;
using Payments.Core.Error;
using Payments.Core.Interfaces.Repository;
using Payments.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Services
{
    public class AuthServcie : IAuthService
    {

        private readonly IAuthRepository repository;
        private readonly TokenConfigure _tokenManagement;

        public AuthServcie(IAuthRepository repository, IOptions<TokenConfigure> _tokenManagement)
        {
            this.repository = repository;
            this._tokenManagement = _tokenManagement.Value;
        }

        public async Task<UserSession> login(USER user)
        {
  
            var logged = await this.repository.login(user);

            if (logged == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "No se encontraron usuarios");
            }

            var token = this.tokenProvider(logged);

            return new UserSession() { usuario = logged, token = token };
        }

        public string tokenProvider(USER usuario)
        {
            var token = string.Empty;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,"User Name"),
                new Claim(ClaimTypes.Email,usuario.Email),
                new Claim(ClaimTypes.PrimarySid,usuario.UserId.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._tokenManagement.secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                this._tokenManagement.issuer, 
                this._tokenManagement.audience, 
                claims, 
                expires: DateTime.Now.AddMinutes(this._tokenManagement.accessExpiration), 
                signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }
    }
}
