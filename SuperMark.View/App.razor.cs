using Microsoft.AspNetCore.Components;
using SuperMark.Common;
using SuperMark.Common.Model;
using SuperMark.View.Auth;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View
{
    public partial class App
    {
        [Inject] NavigationManager navigation { get; set; }
        [Inject] SuperMarketStateProvider authenticationStateProvider { get; set; }
    [Inject] AppState context { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
     
            if (!await authenticationStateProvider.IsAuthenticated())
            {
                navigation.NavigateTo("/security/account/login");
            }
            else
            {

                var identity = GetClaim( await authenticationStateProvider.GetTokenAsync(),"UserLogin");
                if(identity == null)
                {
                    navigation.NavigateTo("/security/account/login");

                }
                var userLogin = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(identity);
                context.User = userLogin;

                navigation.NavigateTo("/",false);
            }

    
        }
        public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }



    }
}
