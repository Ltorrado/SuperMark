using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperMark.View.Auth
{
    public class SuperMarketStateProvider: AuthenticationStateProvider
    {
        /// <summary>
        /// Proveedor de autenticacion 
        /// </summary>
   
            private readonly IJSRuntime _jsRuntime;

            public SuperMarketStateProvider(IJSRuntime jsRuntime)
            {
                _jsRuntime = jsRuntime;


            }

            public async Task<string> GetTokenAsync()
                 => await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            public async Task<bool> SetTokenAsync(string token)
            {
                if (token == null)
                {
                    await _jsRuntime.InvokeAsync<object>("localStorage.removeItem", "authToken");
                }
                else
                {
                    await _jsRuntime.InvokeAsync<object>("localStorage.setItem", "authToken", token);
                }

          await  GetAuthenticationStateAsync();
          

                return true;
            }


            /// <summary>
            /// Verificar si la aplicación esta autenticada
            /// </summary>
            /// <returns></returns>
            public async Task<bool> IsAuthenticated()
            {
                var token = await GetTokenAsync();

                return token != null;
            }

            public override async Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                try
                {
                    var token = await GetTokenAsync();
                 
                    var identity = new ClaimsIdentity( GetClaim(token, "UserLogin"));

                    if (identity == null)
                    {
                        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
                    }
                    else
                    {
                        return new AuthenticationState(new ClaimsPrincipal( identity));

                    }
                }
                catch (Exception)
                {
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
                }

            }
        public List<Claim> GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var stringClaimValue = securityToken.Claims.ToList();
            return stringClaimValue;
        }

    }
}
