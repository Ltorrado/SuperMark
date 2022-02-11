using Microsoft.IdentityModel.Tokens;
using SuperMark.Common.Model;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Managers
{
   public class UserManager
    {
        private readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Metodo para logueo
        /// </summary>
        public async Task<string> Login(string user, string psw)
        {
          var userLogin =  _repository.Login(user, psw);
			if(userLogin != null)
            {
			return	GenerateToken(userLogin);
			}

            
            return "";
        }

		public string GenerateToken(User userId)
		{
			var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
			var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

			var myIssuer = "http://mysite.com";
			var myAudience = "http://myaudience.com";
			var objectstring = Newtonsoft.Json.JsonConvert.SerializeObject(userId);
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim("UserLogin",objectstring),
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = myIssuer,
				Audience = myAudience,
				SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


	}
}
